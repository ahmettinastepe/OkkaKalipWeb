using System.Threading.Tasks;

namespace OkkaKalipWeb.UI.EmailServices.Abstract
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}