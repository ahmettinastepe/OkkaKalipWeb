namespace OkkaKalipWeb.UI.Models
{
    public class AboutModel : BaseModel
    {
        public string ImageUrl { get; set; }
        public string AboutTitle { get; set; }
        public int ExperienceYear { get; set; } = 1;
        public string AboutDescription { get; set; }
        public string ValuesTitle { get; set; }
        public string ValuesDescription { get; set; }
        public string Founder { get; set; }
        public string Rank { get; set; }
        public string Vision { get; set; }
        public string Mission { get; set; }
        public string WorkProcess { get; set; }
        public string YoutubeUrl { get; set; }
        public string YoutubeTitle { get; set; }
        public string YoutubeDescription { get; set; }
        public string YoutubeImageUrl { get; set; }
        public string YoutubeHomeImageUrl { get; set; }
        public string DifferentText { get; set; }
        public string DifferentKeywords { get; set; }
    }
}