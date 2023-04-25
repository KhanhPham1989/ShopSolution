using LibraryAPIApp.Service.Categories;
using LibraryAPIApp.Service.SlideClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopWebData.DbContextData;
using ShopWebException.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<TeduDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString(ConnectionStringcs.Connect)));

            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ISlideClient, SlideClientServiceImp>();

            services.AddTransient<ICategoriesService, CategoriServiceImp>();
            services.AddControllersWithViews();

            services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromMinutes(5));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Categories",
                    pattern: "BabyShop/danh-muc/{id}", new
                    {
                        controller = "ProductApp",
                        action = "Categories"
                    });

                endpoints.MapControllerRoute(
                    name: "Product",
                    pattern: "BabyShop/{danh-muc}/San-pham/{id}",
                    new
                    {
                        controller = "ProductApp",
                        action = "Detail"
                    });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}