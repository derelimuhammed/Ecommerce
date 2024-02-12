using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
	public interface IEmailService
	{
		Task SendMailAsync(string[] tos, string subject, string body);
		Task SendMailAsync(string to, string subject, string body);
		Task ForgetPasswordMailAsync(string to, string resetLink);
		Task ConfirmationMailAsync(string link, string to);
	}
}
