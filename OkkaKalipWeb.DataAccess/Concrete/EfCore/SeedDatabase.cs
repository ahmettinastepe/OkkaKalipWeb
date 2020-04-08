using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.Entities;
using System.Linq;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new NakisKalipContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                    context.Categories.AddRange(Categories);

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategoies);
                }

                if (context.Sliders.Count() == 0)
                    context.Sliders.AddRange(Sliders);

                if (context.Info.Count() == 0)
                    context.Info.Add(Info);

                if (context.News.Count() == 0)
                    context.News.AddRange(News);

                if (context.About.Count() == 0)
                    context.About.Add(About);

                context.SaveChanges();
            }
        }

        private static Category[] Categories =
        {
            new Category() {Name="Telefon"},
            new Category() {Name="Bilgisayar"},
            new Category() {Name="Elektronik"}
        };

        private static Product[] Products =
        {
            new Product() {Name="Samsung S5",Price=1000,ImageUrl="urun-resim-yok.png", Description="Güzel Ürün 1"},
            new Product() {Name="Samsung S6",Price=2000,ImageUrl="urun-resim-yok.png", Description="Güzel Ürün 2"},
            new Product() {Name="Samsung S7",Price=3000,ImageUrl="urun-resim-yok.png", Description="Güzel Ürün 3"},
            new Product() {Name="Samsung S8",Price=4000,ImageUrl="urun-resim-yok.png", Description="Güzel Ürün 4"},
            new Product() {Name="Samsung S9",Price=5000,ImageUrl="urun-resim-yok.png", Description="Güzel Ürün 5"}
        };

        private static ProductCategory[] ProductCategoies =
        {
            new ProductCategory() { Product= Products[0],Category= Categories[0]},
            new ProductCategory() { Product= Products[0],Category= Categories[2]},
            new ProductCategory() { Product= Products[1],Category= Categories[0]},
            new ProductCategory() { Product= Products[1],Category= Categories[1]},
            new ProductCategory() { Product= Products[2],Category= Categories[0]},
            new ProductCategory() { Product= Products[2],Category= Categories[2]},
            new ProductCategory() { Product= Products[3],Category= Categories[1]}
        };

        private static Slider[] Sliders =
        {
            new Slider(){Title="Best solution for Industrial & Factories",Description="WELCOME TO INDUSTRIS...!",ImageUrl="slider-1.jpg"},
            new Slider(){Title="The leading provider  of Industrial ",Description="WELCOME TO INDUSTRIS...!",ImageUrl="slider-2.jpg"},
            new Slider(){Title="Leader in power Automation ",Description="WELCOME TO INDUSTRIS...!",ImageUrl="slider-3.jpg"}
        };

        private static Info Info = new Info
        {
            LogoHeader = "logo.png",
            LogoFooter = "logo-footer.png",
            Address = "Forusbeen 50, 4035 Stavanger, Norway",
            Email1 = "Forusbeen 50, 4035 Stavanger, Norway",
            Email2 = "Forusbeen 50, 4035 Stavanger, Turkey",
            Tel1 = "+84 0378 260 852",
            Tel2 = "+90 0378 260 900",
            FacebookUrl = "www.facebook.com",
            InstagramUrl = "www.instagram.com",
            TwitterUrl = "www.twitter.com",
            YoutubeUrl = "www.youtube.com",
            MapIframe = "<iframe src='https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d99561.99432298371!2d30.555035!3d38.75654!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cf3d7e15ecd85b%3A0xf0c901fb9ada4b16!2sAfyonkarahisar%2C%20Afyonkarahisar%20Merkez%2FAfyonkarahisar!5e0!3m2!1str!2str!4v1585670564385!5m2!1str!2str' width='1170' height='500' frameborder='0' style='border:0;' aria-hidden='false' tabindex='0'></iframe>"
        };

        private static News[] News =
        {
            new News(){ ImageUrl="news-img-1.jpg", Author="Ahmet Tınastepe", Title="Haber 1 Deneme Başlığı", Description="Telenor Connexion has worked with analysts from Stockholm-based consulting firm Northstream to" },
            new News(){ ImageUrl="news-img-2.jpg", Author="Ahmet Tınastepe", Title="Haber 2 Deneme Başlığı", Description="Helenor Connexion has worked with analysts from Stockholm-based consulting firm Northstream to" },
            new News(){ ImageUrl="news-img-3.jpg", Author="Ahmet Tınastepe", Title="Haber 3 Deneme Başlığı", Description="Worked Connexion has worked with analysts from Stockholm-based consulting firm Northstream to" },
            new News(){ ImageUrl="news-img-4.jpg", Author="Ahmet Tınastepe", Title="Haber 4 Deneme Başlığı", Description="Consulting Connexion has worked with analysts from Stockholm-based consulting firm Northstream to" },
            new News(){ ImageUrl="news-img-1.jpg", Author="Ahmet Tınastepe", Title="Haber 5 Deneme Başlığı", Description="Firm Connexion has worked with analysts from Stockholm-based consulting firm Northstream to" },
            new News(){ ImageUrl="news-img-2.jpg", Author="Ahmet Tınastepe", Title="Haber 6 Deneme Başlığı", Description="Northstream Connexion has worked with analysts from Stockholm-based consulting firm Northstream to" }
        };

        private static About About = new About
        {
            ImageUrl="about-img.jpg",
            AboutTitle= "Industris 1994-2019",
            ExperienceYear=20,
            AboutDescription= "We’re Industris, a broad energy company with a proud history. We are 20,000 committed colleagues developing oil, gas, wind and solar energy in more than 30 countries worldwide. We’re the largest operator in Norway, one of the world’s largest offshore operators, and a growing force in renewables. Driven by our Nordic urge to explore beyond the horizon and dedication to safety, equality and sustainability, we’re developing the energy of the future.",
            ValuesTitle= "Our values",
            ValuesDescription= "We are the leading operator on the Norwegian continental shelf and have substantial international activities. We are engaged in exploration, development and production of oil and gas, as well as wind and solar power. We sell crude oil and are a major supplier of natural gas, with activities in processing, refining, and trading. Our activities are managed through eight business areas, staffs and support divisions, and we have operations in North and South America, Africa, Asia, Europe and Oceania, and Norway.",
            Founder= "Arya Star",
            Rank= "CEO, Founder",
            Vision= "When, while the lovely valley teems with vapour around me, and the meridian sun strikes the upper surface of the impenetrable foliage of my trees, and but a few stray gleams steal into the inner sanctuary, I throw myself down among the tall grass by the trickling stream; and, as I lie close to the earth, a thousand unknown",
            Mission= "When, while the lovely valley teems with vapour around me, and the meridian sun strikes the upper surface of the impenetrable foliage of my trees, and but a few stray gleams steal into the inner sanctuary, I throw myself down among the tall grass by the trickling stream; and, as I lie close to the earth, a thousand unknown",
            WorkProcess= "Over the course of more than 25 years of hard work with many large and small projects. We have worked out the best working process.",
            YoutubeUrl= "https://youtu.be/YrbQIN2TBhM",
            YoutubeTitle= "VISION & MISSION STATTEMENT",
            YoutubeDescription= "Connecting things, It’s all about people.",
            YoutubeImageUrl="bg-about-video-jpg",
            YoutubeHomeImageUrl="home-video-img.jpg"
        };
    }
}