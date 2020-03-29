using IoCTest.Integrations.Email.Interfaces;

namespace IoCTest.Integrations.Email.Generators
{
	public class TextGenerator : IEmailBodyGenerator
    {
        public bool IsHtml { get; } = false;

        public string GenerateBodyString(object model)
        {
            // Build text string from model.

            return $"The generated text string from type: {model.GetType().FullName}";
        }
    }
}
