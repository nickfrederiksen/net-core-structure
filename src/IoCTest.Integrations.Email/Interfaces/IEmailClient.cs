using System.Threading.Tasks;

namespace IoCTest.Integrations.Email.Interfaces
{
	public interface IEmailClient
	{
		Task SendEmailAsync(string to, string from, string subject, object emailBody);
	}
}