using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using TravelokaV2.Application.Services.Security;

namespace TravelokaV2.Infrastructure.Persistence.Services.Security
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _senderEmail;
        private readonly string _senderPassword;

        public EmailSender(IConfiguration config)
        {
            _config = config;
            _smtpServer = _config["GmailSMTP:smtpServer"]!;
            _smtpPort = _config.GetValue<int>("GmailSMTP:smtpPort")!;
            _senderEmail = _config["GmailSMTP:senderEmail"]!;
            _senderPassword = _config["GmailSMTP:senderPassword"]!;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_senderEmail, _senderPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_senderEmail),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);
            try
            {
                await client.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                throw new Exception($"Lỗi ở đây: {ex.Message}", ex);
            }

        }
    }
}
