using System.ComponentModel.DataAnnotations;

namespace OkkaKalipWeb.UI.Models
{
    public class InfoModel : BaseModel
    {
        [Required(ErrorMessage ="Firmanız için bir logo seçimi zorunludur.")]
        public string LogoHeader { get; set; }

        public string LogoFooter { get; set; }

        [Required(ErrorMessage = "Firmanız için bir adres yazmalısınız.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Firmanız için en az bir Email adresi girmelisiniz.")]
        public string Email1 { get; set; }

        public string Email2 { get; set; }

        [Required(ErrorMessage = "Firmanız için en az bir telefon numarası adresi girmelisiniz.")]
        public string Tel1 { get; set; }

        public string Tel2 { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public string MapIframe { get; set; }
        public string SiteTitle { get; set; }
        public string Keywords { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}