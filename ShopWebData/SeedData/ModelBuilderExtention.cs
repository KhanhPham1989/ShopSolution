using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWebData.Entities;
using ShopWebData.Enum;

namespace ShopWebData.Extention
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(new List<User>()
            //{
            //    new User{UserId = Guid.NewGuid(), UserName = "abcd",PassWord = "abcd", FullName = "TeduShop",Email = "Tedu@gmail.com",PhoneNumber ="0123456789",DoB = DateTime.Now},
            //    new User{UserId = Guid.NewGuid(), UserName = "xxxx",PassWord = "xxx", FullName = "TeduShopxxx",Email = "Teduxxx@gmail.com",PhoneNumber ="0123456987",DoB = DateTime.Now},
            //});

           // modelBuilder.Entity<ProductTranslation>().HasNoKey();
           
            for (int i = 1; i < 20; i++)
            {
                var item = new Product()
                {
                    Id = i,
                    ProductName = $"SanPham 0{i}",
                    Price = 1000 + i, //decimal.Parse(Guid.NewGuid().ToString().Trim().Substring(8)),
                    OriginalPrice = 2000 + i, //decimal.Parse(Guid.NewGuid().ToString().Trim().Substring(7)),
                    Stock = 10 + i,
                    DateCreated = DateTime.Now,
                    Description = $"San pham thu {i} cua SamSung",
                    ViewCount = i + 20,
                    SeoAlias = $"ABCD{i}"
                };
                modelBuilder.Entity<Product>().HasData(item);
            }

            for (int i = 0; i < 10; i++)
            {
                var user = new AppUser()
                {
                    Id = Guid.NewGuid(),
                    FullName = $"Nguyen Van {i}",
                    UserName = $"Ten{i}",
                    Email = $"abc{i}@gmail.com",
                    PhoneNumber = $"012345678{i}",
                    PasswordHash = $"{i}11111",
                    LastLoginDate = DateTime.Now
                };
                modelBuilder.Entity<AppUser>().HasData(user);
            }

            //modelBuilder.Entity<ProductTranslation>().HasData(new List<ProductTranslation>
            //{
            //    new ProductTranslation
            //    {
                   
            //        ProductId = 1,
            //        Name = "asdvb",
            //        Description = "Ao Viet Tien",
            //        Details = " Hang Viet Nam",
            //        SeoDescription = "VN",
            //        SeoTitle = "Ao tay dai",
            //        SeoAlias = "Short Skirt",
                    
            //        Language = new Language
            //        {
            //            LangueId =1,
            //            LangName = "VN",
            //            IsDefault = Status.Active,
            //        },
            //        Product = new Product
            //        {
            //            Id = 20,
            //            ProductName = "SanPham 20",
            //            Description = "San pham thu 20",
            //            Price = 2000,
            //            OriginalPrice = 3000,
            //            Stock = 25,
            //            ViewCount = 2,
            //            DateCreated = DateTime.Now,
            //            SeoAlias = "ABC20"
            //        }
            //    },
            //    new ProductTranslation
            //    {
                   
            //        ProductId = 2,
            //        Name = "abchiuy",
            //        Description = "Ao China",
            //        Details = " Hang China",
            //        SeoDescription = "VN",
            //        SeoTitle = "Ao tay ngan",
            //        SeoAlias = "Long Skirt",
              
            //        Language = new Language
            //        {
                        
            //            LangueId =2,
            //            LangName = "EG",
            //            IsDefault = Status.Active,
            //        },
            //         Product = new Product
            //        {
            //            Id = 21,
            //            ProductName = "SanPham 21",
            //            Description = "San pham thu 21",
            //            Price = 21000,
            //            OriginalPrice = 31000,
            //            Stock = 225,
            //            ViewCount = 23,
            //            DateCreated = DateTime.Now,
            //            SeoAlias = "ABC21"
            //        }
            //    },
            //});
        }
    }
}
// chỉnh lại bảng langue id là string 
