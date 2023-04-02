using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWebData.AppConfiguration;
using ShopWebData.Entities;
using ShopWebData.Extention;
using Action = ShopWebData.Entities.Action;
using Configuration = ShopWebData.Entities.Configuration;

namespace ShopWebData.DbContextData
{
    public class TeduDbContext : IdentityDbContext<AppUser,RoleIdentity,Guid>
    {
        public TeduDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings[""].ConnectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // đăng ký attribute cho bảng appConfig từ AppConfigConfiguration
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfig());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfig());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfig());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfig());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim").HasKey(x => x.Id);
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole").HasKey((x) =>  new {x.RoleId,x.UserId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin").HasKey(x=> x.UserId);
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken").HasKey(x => x.UserId);

            // d

            base.OnModelCreating(modelBuilder);

            // xoa tien to ASP o truoc bang 
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = item.GetTableName();
                if(tableName.StartsWith("AspNet"))
                {
                    item.SetTableName(tableName.Substring(6));
                }
            }

            // seed data
            modelBuilder.Entity<AppConfig>().HasData(new List<AppConfig>()
            {
                new AppConfig{ Key = 001,Keys = "HomePage",Value = "This is HomePage"},
                new AppConfig{ Key = 002,Keys = "ContactPage",Value = "This is ContactPage"},
                new AppConfig{ Key = 003,Keys = "InfomationPage",Value = "This is InfomationPage"},
            });

            modelBuilder.Seed();

        }

        //public DbSet<Action> Actions { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        //public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Funtion> Funtions { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<SystemActivities> SystemActivities { get; set; }
       
        public DbSet<ProductInCaterogy> ProductCategory { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

       

    }
}
