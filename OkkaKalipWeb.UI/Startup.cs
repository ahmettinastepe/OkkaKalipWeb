using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Business.Concrete;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.DataAccess.Concrete.EfCore;
using OkkaKalipWeb.UI.EmailServices;
using OkkaKalipWeb.UI.EmailServices.Abstract;
using OkkaKalipWeb.UI.Identity;
using OkkaKalipWeb.UI.Middlewares;
using System;

namespace OkkaKalipWeb.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // password

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".NakisKalipApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

            services.AddScoped<IProductDal, EfCoreProductDal>();
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
            services.AddScoped<ICartDal, EfCoreCartDal>();
            services.AddScoped<ISliderDal, EfCoreSliderDal>();
            services.AddScoped<IInfoDal, EfCoreInfoDal>();
            services.AddScoped<INewsDal, EfCoreNewsDal>();
            services.AddScoped<IAboutDal, EfCoreAboutDal>();
            services.AddScoped<IServiceDal, EfCoreServiceDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<IInfoService, InfoManager>();
            services.AddScoped<INewsService, NewsManager>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutServicesService, AboutServicesManager>();

            services.AddTransient<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.CustomStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "adminSliders", "admin/slider", defaults: new { controller = "Slider", action = "SliderList" });
                endpoints.MapControllerRoute(name: "adminSliders", "admin/slider/{id?}", defaults: new { controller = "Slider", action = "EditSlider" });
                endpoints.MapControllerRoute(name: "adminProducts", "admin/products", defaults: new { controller = "Product", action = "ProductList" });
                endpoints.MapControllerRoute(name: "adminProducts", "admin/products/{id?}", defaults: new { controller = "Product", action = "EditProduct" });
                endpoints.MapControllerRoute(name: "products", "products/{category?}", defaults: new { controller = "Shop", action = "Index" });
                endpoints.MapControllerRoute(name: "news", "news", defaults: new { controller = "News", action = "Index" });
                endpoints.MapControllerRoute(name: "admin", "admin/index", defaults: new { controller = "Admin", action = "Index" });
                endpoints.MapControllerRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "cart", "cart", defaults: new { controller = "Cart", action = "Index" });
            });

         //   SeedIdentity.Seed(userManager, roleManager, Configuration).Wait();
        }
    }
}