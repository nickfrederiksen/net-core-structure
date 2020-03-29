using IoCTest.Integrations.Email.Interfaces;

namespace IoCTest.Integrations.Email.Generators
{
	public class HtmlGenerator : IEmailBodyGenerator
	{
		public bool IsHtml { get; } = true;

		public string GenerateBodyString(object model)
		{
			// Build html document from model.

			return $"The generated html from type: {model.GetType().FullName}";
		}
	}
}
