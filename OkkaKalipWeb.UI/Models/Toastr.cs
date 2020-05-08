using OkkaKalipWeb.UI.Enums;

namespace OkkaKalipWeb.UI.Models
{
    public class Toastr
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public ToastrType ToastrType { get; set; }

        public Toastr()
        {

        }

        public Toastr(string message, string title = "Bilgi", ToastrType toastrType = ToastrType.Info)
        {
            Message = message;
            Title = title;
            ToastrType = toastrType;
        }

        public static string GetMessage(string title, EntityStatus entityStatus = EntityStatus.Create)
        {
            return entityStatus switch
            {
                EntityStatus.Create => $"Yeni {title} Listeye Eklendi",
                EntityStatus.Update => $"{title} Başaryıla Güncellendi",
                EntityStatus.Delete => $"{title} Kalıcı Olarak Silindi",
                _ => "Bir Hata Meydana Geldi. İşlem Başarısız",
            };
        }

        public static string GetTitle(string title, EntityStatus entityStatus = EntityStatus.Create)
        {
            return entityStatus switch
            {
                EntityStatus.Create => $"Yeni {title}",
                EntityStatus.Update => $"{title} Güncelleme",
                EntityStatus.Delete => $"{title} Silme",
                _ => "Bir Hata Meydana Geldi. İşlem Başarısız",
            };
        }
    }
}