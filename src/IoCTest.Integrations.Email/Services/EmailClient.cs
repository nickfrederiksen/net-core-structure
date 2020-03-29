using System.Net.Mail;
using System.Threading.Tasks;
using IoCTest.Integrations.Email.Interfaces;

namespace IoCTest.Integrations.Email.Services
{
	public class EmailClient : IEmailClient
	{
		private readonly IEmailBodyGenerator bodyGenerator;
		private readonly SmtpClient smtpClient;

public EmailClient(
	IEmailBodyGenerator bodyGenerator,
	SmtpClient smtpClient)
{
	this.bodyGenerator = bodyGenerator;
	this.smtpClient = smtpClient;
}

		public Task SendEmailAsync(string to, string from, string subject, object emailBody)
		{

			var message = new MailMessage(from, to);
			message.Subject = subject;
			message.IsBodyHtml = this.bodyGenerator.IsHtml;
			message.Body = this.bodyGenerator.GenerateBodyString(emailBody);

			return this.smtpClient.SendMailAsync(message);
		}
	}
}
