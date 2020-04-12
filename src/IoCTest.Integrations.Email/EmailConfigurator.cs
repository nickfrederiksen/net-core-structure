using IoCTest.Integrations.Email.Generators;
using IoCTest.Integrations.Email.Interfaces;
using IoCTest.Integrations.Email.Options;
using IoCTest.Integrations.Email.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;

namespace IoCTest.Integrations.Email
{
	public static class EmailConfigurator
	{
		public static void AddEmailServices(this IServiceCollection services, Action<EmailOptions> emailOptions)
		{
			services.Configure(emailOptions);

			services.AddScoped<IEmailClient, EmailClient>();
			services.AddScoped<SmtpClient>(
				provider =>
				{
					var options = provider.GetRequiredService<IOptionsMonitor<EmailOptions>>().CurrentValue;
					var client = new SmtpClient(options.Host);

					client.Credentials = new System.Net.NetworkCredential(options.Username, options.Password);

					return client;
				});
			services.AddScoped<IEmailBodyGenerator, HtmlGenerator>();
		}
	}
}
