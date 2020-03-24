using OkkaKalipWeb.UI.EmailServices.Abstract;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace OkkaKalipWeb.UI.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private const string SendApiKey = "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";

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(SendApiKey, subject, htmlMessage, email);
        }

        // will be updated
        public Task Execute(string sendApiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(sendApiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("info@nakiskalip.com", "Nakış Kalıp"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));

            return client.SendEmailAsync(msg);
        }
    }
}