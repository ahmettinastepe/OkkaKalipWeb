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
    }
}