using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCTest.Integrations.Email.Options
{
	public class EmailOptions
	{
		public string Host { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string SenderEmail { get; set; }

		public string SenderName { get; set; }

		public string ReplyTo { get; set; }

		public IEnumerable<string> To { get; set; }

		public IEnumerable<string> CC { get; set; }

		public IEnumerable<string> BCC { get; set; }
	}
}
