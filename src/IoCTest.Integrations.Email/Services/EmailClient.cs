using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using IoCTest.Integrations.Email.Interfaces;
using IoCTest.Integrations.Email.Options;
using Microsoft.Extensions.Options;

namespace IoCTest.Integrations.Email.Services
{
	public class EmailClient : IEmailClient
	{
		private readonly IEmailBodyGenerator bodyGenerator;
		private readonly SmtpClient smtpClient;

		public EmailOptions options { get; }

		public EmailClient(
			IEmailBodyGenerator bodyGenerator,
			SmtpClient smtpClient,
			IOptionsSnapshot<EmailOptions> options)
		{
			this.bodyGenerator = bodyGenerator;
			this.smtpClient = smtpClient;
			this.options = options.Value;
		}

		public Task SendEmailAsync(string to, string subject, object emailBody)
		{
			MailMessage message = this.CreateMessage(to);

			message.Subject = subject;
			message.IsBodyHtml = this.bodyGenerator.IsHtml;
			message.Body = this.bodyGenerator.GenerateBodyString(emailBody);

			return this.smtpClient.SendMailAsync(message);
		}

		private MailMessage CreateMessage(string to)
		{
			MailAddress sender = new MailAddress(this.options.SenderEmail, this.options.SenderName);
			MailAddress receiver = new MailAddress(to);

			var message = new MailMessage(sender, receiver);
			message.ReplyToList.Add(this.options.ReplyTo);

			this.AddAddresses(this.options.BCC, message.Bcc);
			this.AddAddresses(this.options.CC, message.CC);
			this.AddAddresses(this.options.To, message.To);

			return message;
		}

		private void AddAddresses(IEnumerable<string> addresses, MailAddressCollection collection)
		{
			if (addresses != null)
			{
				foreach (var item in addresses)
				{
					collection.Add(item);
				}
			}
		}
	}
}
