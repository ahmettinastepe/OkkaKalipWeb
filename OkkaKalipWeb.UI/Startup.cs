using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Business.Concrete;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.DataAccess.Concrete.EfCore;
using OkkaKalipWeb.UI.Middlewares;

namespace OkkaKalipWeb.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddScoped<IProductDal, EfCoreProductDal>();
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.CustomStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "products", "products/{category?}", defaults: new { controller = "Shop", action = "Index" });
                endpoints.MapControllerRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}