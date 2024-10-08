using Domain.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Domain.Helpers;
using System.Net.Mail;

namespace Domain
{
   
    public class EmailService:IMailService
    {
        private readonly MailSettings _mailsetting;
        private readonly IConfiguration _config;
        public EmailService(IOptions<MailSettings> mailSettings, IConfiguration config)
        {
            _mailsetting = mailSettings.Value;
            _config = config;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var FromMail = _config.GetSection("MailSettings")["FromMail"];
                var DisplayName = _config.GetSection("MailSettings")["DisplayName"];
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(DisplayName, FromMail));
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
               smtp.CheckCertificateRevocation = false;


                smtp.Connect(_mailsetting.Host, _mailsetting.Port, _mailsetting.UseSSL);
                var DoAuthenticate = _config.GetSection("MailSettings")["DoAuthenticate"];
                // if (DoAuthenticate)
                //{
                smtp.Authenticate(_mailsetting.UserMail, _mailsetting.Password);
                //}
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
