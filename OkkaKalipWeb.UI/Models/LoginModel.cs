using System.ComponentModel.DataAnnotations;

namespace OkkaKalipWeb.UI.Models
{
    public class LoginModel : BaseModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}