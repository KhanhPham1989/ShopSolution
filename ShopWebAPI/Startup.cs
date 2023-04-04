using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ShopWebApplication.Catalog.Products;
using ShopWebApplication.Catalog.User;
using ShopWebApplication.Common;
using ShopWebData.DbContextData;
using ShopWebData.Entities;
using ShopWebException.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebAPI
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
            services.AddDbContext<TeduDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString(ConnectionStringcs.Connect)));

            services.AddIdentity<AppUser, RoleIdentity>()
                    .AddEntityFrameworkStores<TeduDbContext>()
                    .AddDefaultTokenProviders();
            services.AddTransient<IStoreService, PublicIstorageService>();
            services.AddTransient<IManageProductService, ManageProductService>();
            services.AddTransient<IPublicProductService, PublicProductService>();
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<RoleIdentity>, RoleManager<RoleIdentity>>();
            services.AddTransient<IUserService, UserServiceImp>();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Thiết lập về Passwor;
            //    options.Password.RequireDigit = false; //Không bắt phải có số
            //    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
            //    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
            //    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
            //    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
            //    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

            //    // Cấu hình Lockout - khóa user
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
            //    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
            //    options.Lockout.AllowedForNewUsers = true;

            //    // Cấu hình về User.
            //    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
            //        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    options.User.RequireUniqueEmail = true;  // Email là duy nhất

            //    // Cấu hình đăng nhập.
            //    options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
            //    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
            //    options.SignIn.RequireConfirmedAccount = true;
            //});

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swager ShopOnlineAPI", Version = "v1" }));
            services.AddControllersWithViews();
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
            app.UseSwagger();
            app.UseSwaggerUI(p => p.SwaggerEndpoint("/swagger/v1/swagger.json", "Swager ShopOnlineAPI"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}