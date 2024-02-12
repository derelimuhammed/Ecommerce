using System;
using System.Collections.Generic;
using System.Linq;

using System.Net;
using System.Text;
using System.Threading.Tasks;
using Business.Abstarct;
using Core.Configurations;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;


namespace Business.Concrete
{
	 public class EmailManager : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly IConfiguration _configuration;
		public EmailManager(IOptions<EmailSettings> options, IConfiguration configuration)
		{
			_emailSettings = options.Value;
			_configuration = configuration;
		}
		public async Task SendMailAsync(string to, string subject, string body)
        { 
            await SendMailAsync(new[] { to }, subject, body );
        }

        public  async Task SendMailAsync(string[] tos, string subject, string body)
        {
            MimeMessage mimeMessage = new();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("E-Commerce",_emailSettings.Email);
            foreach (var to in tos)
            {
             MailboxAddress mailboxAddressTo = new MailboxAddress("User", to);
             mimeMessage.To.Add(mailboxAddressTo);
            }
            mimeMessage.From.Add(mailboxAddressFrom);
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            mimeMessage.Subject = subject;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            SmtpClient smtp = new();
           await smtp.ConnectAsync(_emailSettings.Host,_emailSettings.Port, false);
           await smtp.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
           await smtp.SendAsync(mimeMessage);
           await smtp.DisconnectAsync(true);
        }
        
        public async Task ForgetPasswordMailAsync(string to, string resetLink)
        {
            
            StringBuilder mail = new();
            mail.AppendLine("<html><body>");
            mail.AppendLine($"<p>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.</p>");
            mail.AppendLine($"<p><strong><a target=\"_blank\" href=\"{resetLink}\">Yeni şifre talebi için tıklayınız...</a></strong></p>");
            mail.AppendLine("<p><span style=\"font-size:12px;\">NOT: Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span></p>");
            mail.AppendLine("<p>Saygılarımızla...</p>");
            mail.AppendLine("</body></html>");
            await SendMailAsync(to, "Şifre Yenileme Talebi", mail.ToString());
        }
        public async Task ConfirmationMailAsync(string link, string to)
        {
           StringBuilder mail = new();
            mail.AppendLine("<html><body>");
            mail.AppendLine($"<p>Eğer Email Onaylama talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.</p>");
            mail.AppendLine($"<p><strong><a target=\"_blank\" href=\"{link}\">Emailinizi Onaylamak için lütfen tıklayın</a></strong></p>");
            mail.AppendLine("<p><span style=\"font-size:12px;\">NOT: Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span></p>");
            mail.AppendLine("<p>Saygılarımızla...</p>");
            mail.AppendLine("</body></html>");
            await SendMailAsync(to, "Email Onaylama Talebi", mail.ToString());
        }
	}
}
