using BWE.Domain.Model;
using BWE.Domain.Settings;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace BWE.Application.Mail
{
    public class MailHelper : IMailHelper
    {
        private readonly MailSettings _settings;

        public MailHelper(MailSettings settings)
        {
            _settings = settings;
        }

        private MimeMessage CreateMimeMessageFromEmailMessage(EmailMessageModel message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(message.Sender);
            mimeMessage.To.Add(message.Reciever);
            mimeMessage.Subject = message.Subject;
            var bodyBuilder = new BodyBuilder { HtmlBody = message.Content };
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            return mimeMessage;
        }

        public async Task SendEmail(string sendTo, string subject, string body)
        {
            try
            {
                await Task.Run(async () =>
                {
                    var mailMsg = new EmailMessageModel();
                    mailMsg.Sender = new MailboxAddress(_settings.Title, _settings.Sender);
                    mailMsg.Reciever = new MailboxAddress(_settings.Title, sendTo);
                    mailMsg.Subject = subject;
                    mailMsg.Content = body;
                    var mimeMessage = Task.Run(() => CreateMimeMessageFromEmailMessage(mailMsg)).Result;

                    using (SmtpClient client = new SmtpClient())
                    {
                        client.Connect(_settings.SmtpServer, _settings.Port, SecureSocketOptions.Auto);
                        client.Authenticate(_settings.UserName, _settings.Password);
                        client.Send(mimeMessage);
                        client.Disconnect(true);
                    }
                });
            }
            catch(System.Exception ex)
            {
                var p = ex;
            }
            
        }
    }
}
