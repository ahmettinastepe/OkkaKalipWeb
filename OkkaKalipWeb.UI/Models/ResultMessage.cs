namespace OkkaKalipWeb.UI.Models
{
    public class ResultMessage : BaseModel
    {
        public override string Title { get; set; }
        public string Message { get; set; }
        public string Css { get; set; }
    }
}