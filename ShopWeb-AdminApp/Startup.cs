using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LibraryAPIApp.Service.Categories;
using LibraryAPIApp.Service.Product;
using LibraryAPIApp.Service.RoleClient;
using LibraryAPIApp.Service.User;
using ShopWebModels.Catalog.User.ValadateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPIApp.Service.SlideClient;

namespace ShopWeb_AdminApp
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
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleClientService, IRoleClientServiceImp>();
            services.AddTransient<IProductClientInterface, ProductClientIpm>();
            services.AddTransient<ICategoriesService, CategoriServiceImp>();
            services.AddTransient<ISlideClient, SlideClientServiceImp>();

            services.AddControllersWithViews().AddFluentValidation(fw =>
            {
                fw.RegisterValidatorsFromAssemblyContaining<LoginValidate>();
                fw.RegisterValidatorsFromAssemblyContaining<RegisterValidate>();
            });

            services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromMinutes(5)); // gan thoi gian cho session

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            IMvcBuilder builder = services.AddRazorPages();
            var enviroments = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
#if DEBUG
            if (enviroments == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
#endif

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.LoginPath = "/Login/Index";
                opt.AccessDeniedPath = "/User/AccessDenied";
            });
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
                app.UseExceptionHandler("/Home1/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home1}/{action=Index}/{id?}");
            });
        }
    }
}