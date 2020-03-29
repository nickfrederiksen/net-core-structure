using System.Net.Mail;
using IoCTest.Integrations.Email.Generators;
using IoCTest.Integrations.Email.Interfaces;
using IoCTest.Integrations.Email.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IoCTest.Integrations.Email
{
    public static class EmailConfigurator
    {
public static void AddEmailServices(this IServiceCollection services)
{
    services.AddScoped<IEmailClient, EmailClient>();
    services.AddScoped<SmtpClient>();
    services.AddScoped<IEmailBodyGenerator, HtmlGenerator>();
}
    }
}
