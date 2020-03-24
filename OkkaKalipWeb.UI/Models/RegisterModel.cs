using System.ComponentModel.DataAnnotations;

namespace OkkaKalipWeb.UI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Lütfen tam isminizi girin.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Lütfen bir kullanıcı adı belirleyin. (Bu isim giriş işleminde kullanılacak)")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen bir şifre belirleyin"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi tekrar girin"), DataType(DataType.Password), Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Lütfen geçerli bir mail adresi girin"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}