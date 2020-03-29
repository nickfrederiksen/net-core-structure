namespace IoCTest.Integrations.Email.Interfaces
{
	public interface IEmailBodyGenerator
	{
		bool IsHtml { get; }

		string GenerateBodyString(object model);
	}
}