using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopWebApplication.Common;
using ShopWebData.DbContextData;
using ShopWebData.Entities;
using ShopWebException.TeduException;
using ShopWebModels.Catalog;
using ShopWebModels.Catalog.Images;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ShopWebException.Common;
using ShopWebModels.Catalog.Categories;
using Microsoft.AspNetCore.Hosting;

namespace ShopWebApplication.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly IStoreService _Istoreservice;
        private readonly TeduDbContext data;

        public ManageProductService(TeduDbContext _data, IStoreService Istoreservice)
        {
            data = _data;
            _Istoreservice = Istoreservice;
        }

        public async Task<int> AddImages(int productId, ImageCreateRequest request)
        {
            var product = await data.Products.FindAsync(productId);
            if (product == null)
                throw new Exception($"{productId} not exits...");
            var productImage = new ProductImage
            {
                Caption = request.Caption,
                DateCreate = DateTime.Now,
                IsDefault = request.IsDefault,
                SortOrder = request.SortOrder,
                ProductId = productId
            };
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            data.ProductImages.Add(productImage);
            await data.SaveChangesAsync();
            return productImage.Id;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var languegs = data.Languages;
            var translation = new List<ProductTranslation>();
            foreach (var langueg in languegs)
            {
                if (request.langId == langueg.LangueId)
                {
                    translation.Add(new ProductTranslation()
                    {
                        LangueId = request.langId,
                        Description = request.Description,
                        Details = request.Details,
                        SeoAlias = request.SeoAlias,
                        SeoDescription = request.SeoDescription,
                        SeoTitle = request.SeoTitle,
                        Name = request.LangName
                    });
                }
            }
            var product = new Product
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                ProductName = request.Name,
                SeoAlias = request.SeoAlias,
                DateCreated = DateTime.Now,
                Description = request.Description,
                ProductTranslations = translation,
                IsFeatured = true,
            };

            // Save Image
            // Kiem tra trong object gui toi co hinh anh hya ko
            if (request.ThumbnaiImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage
                    {
                        Caption = request.CaptionImage,
                        DateCreate = DateTime.Now,
                        FileSize = request.ThumbnaiImage.Length,
                        ImagePath =  await this.SaveFile(request.ThumbnaiImage),
                        IsDefault = true,
                        SortOrder = 1,
                    }
                };
            }

            data.Products.Add(product);
            await data.SaveChangesAsync();
            var cateloId = new ProductInCaterogy() { CategoryId = request.CateId, ProductId = product.Id };

            data.ProductCategory.Add(cateloId);
            await data.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productId)
        {
            var product = await data.Products.FindAsync(productId);
            if (product == null) throw new Exception("Can not find Product" + productId);
            var images = data.ProductImages.Where(x => x.ProductId == productId);
            if (images != null)
            {
                foreach (var image in images)
                {
                    await _Istoreservice.DeleteFileAsync(image.ImagePath);
                }
            }
            data.Products.Remove(product);
            return await data.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            var product = await data.Products.ToListAsync();

            return product;
        }

        public async Task<APIResult<PageResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request)
        {
            // select and join
            var query = from p in data.Products
                        join pt in data.ProductTranslations on p.Id equals pt.ProductId into ppt
                        from pt in ppt.DefaultIfEmpty()
                        join pi in data.ProductImages on p.Id equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        join pic in data.ProductCategory on p.Id equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in data.Categories on pic.CategoryId equals c.Id into pc
                        from c in pc.DefaultIfEmpty()
                        where request.Categori.Equals(pic.CategoryId) /*&& pt.LangueId == request.langugeId*/
                        select new { p, pic, c, pi };
            // join cac banng theo ID lien ket, tra ve ket qua theo bang ben trai bat chap gia tri bang ben phai la null
            // ket qua tra ve theo bang ben trai va value la null

            // filter
            if (!string.IsNullOrEmpty(request.Key))
            {
                query = query.Where(x => x.p.ProductName.Contains(request.Key));
            }

            //if (request.CategoryId.Count > 0 && request.CategoryId != null)
            //    query = query.Where(x => request.CategoryId.Contains(x.pic.CategoryId));
            // paging

            if (request.Categori != null && request.Categori != 0)
                query = query.Where(x => request.Categori.Equals(x.pic.CategoryId));

            var totalRow = await query.CountAsync();
            var resurl = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    ProductName = x.p.ProductName,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Description = x.p.Description,
                    CategoriId = x.c.Id,
                    ThumnailFile = x.pi.ImagePath
                }).ToListAsync();

            // select and projection
            var pageRecord = new PageResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                Item = resurl,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            var final = new APISuccessResult<PageResult<ProductViewModel>>()
            {
                ObjResult = pageRecord,
            };
            return final;
        }

        public async Task<ProductViewModel> GetById(int productId, int languageID)
        {
            var product = await data.Products.Where(x => x.Id == productId).SingleOrDefaultAsync();
            var cate = await data.ProductCategory.Where(x => x.ProductId == productId).SingleOrDefaultAsync();
            var image = await data.ProductImages.Where(x => x.ProductId == productId).SingleOrDefaultAsync();

            var productTranslation = await data.ProductTranslations.
                    FirstOrDefaultAsync(x => x.ProductId == productId && x.LangueId == languageID);
            if (product == null)
                return null;

            if (productTranslation == null)
            {
                var productViewModels = new ProductViewModel
                {
                    ProductName = product.ProductName,
                    Price = product.Price,
                    OriginalPrice = product.OriginalPrice,
                    Stock = product.Stock,
                    Description = ConnectionStringcs.Na,
                    SeoAlias = ConnectionStringcs.Na,
                    SeoDescription = ConnectionStringcs.Na,
                    DateCreated = product.DateCreated,
                    SeoTitle = ConnectionStringcs.Na,
                    ViewCount = product.ViewCount,
                    languageID = languageID,
                    TranslationDetails = ConnectionStringcs.Na,
                    CategoriId = cate.CategoryId
                };

                var input = new ProductTranslation()
                {
                    ProductId = productId,
                    LangueId = languageID,
                    Description = ConnectionStringcs.Na,
                    SeoAlias = ConnectionStringcs.Na,
                    SeoDescription = ConnectionStringcs.Na,
                    SeoTitle = ConnectionStringcs.Na,
                };
                await data.ProductTranslations.AddAsync(input);
                await data.SaveChangesAsync();
                return productViewModels;
            }

            var path = _Istoreservice.GetFileUrl("No.jpg");

            var productViewModel = new ProductViewModel
            {
                ProductName = product.ProductName,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Stock = product.Stock,
                Description = productTranslation.Description,
                SeoAlias = productTranslation.SeoAlias,
                SeoDescription = productTranslation.SeoDescription,
                DateCreated = product.DateCreated,
                SeoTitle = productTranslation.SeoTitle,
                ViewCount = product.ViewCount,
                TranslationDetails = productTranslation.Details,
                CategoriId = cate.CategoryId != 0 ? cate.CategoryId : 2,
                ThumnailFile = image == null ? path : image.ImagePath
            };
            return productViewModel;
        }

        public async Task<ProductViewModel> GetByIdNoLanguage(int productId)
        {
            var product = await data.Products.FindAsync(productId);
            var productTranslation = await data.ProductTranslations.
                    FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
                return null;

            var productViewModel = new ProductViewModel
            {
                ProductName = product.ProductName,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Stock = product.Stock,
                Description = productTranslation == null ? productTranslation.Description : null,
                SeoAlias = productTranslation == null ? productTranslation.SeoAlias : null,
                SeoDescription = productTranslation == null ? productTranslation.SeoDescription : null,
                DateCreated = product.DateCreated,
                SeoTitle = productTranslation == null ? productTranslation.SeoTitle : null,
                ViewCount = product.ViewCount
            };
            return productViewModel;
        }

        public async Task<ImageViewModels> GetImageById(int ImageId)
        {
            var productImage = await data.ProductImages.FindAsync(ImageId);
            if (productImage == null)
                //return -1;
                throw new ShopException("Image not exits!");

            var image = new ImageViewModels()
            {
                Caption = productImage.Caption,
                DateCreate = productImage.DateCreate,
                ThumbnailFile = productImage.ThumbnailFile,
                ImagePath = productImage.ImagePath,
                IsDefault = productImage.IsDefault,
                ImageId = productImage.Id,
            };
            return image;
        }

        public async Task<List<ImageViewModels>> GetListImages(int productId)
        {
            var check = await data.Products.FindAsync(productId);
            if (check == null)
                throw new Exception($"{productId} doesn't exit in List Product");

            var products = await data.ProductImages.Where(x => x.ProductId == productId).Select(x => new ImageViewModels()
            {
                Caption = x.Caption,
                DateCreate = x.DateCreate,
                ThumbnailFile = x.ThumbnailFile,
                ImagePath = x.ImagePath,
                IsDefault = x.IsDefault,
                ImageId = x.Id,
                productName = check.ProductName
            }).ToListAsync(); ;

            return products;
        }

        public async Task<int> RemoveImages(int productId, int ImageId)
        {
            var checkProduct = await data.Products.FindAsync(productId);
            if (checkProduct == null)
                throw new Exception($"{productId} not exits in Product List");

            var productImage = await data.ProductImages.SingleOrDefaultAsync(x => x.Id == ImageId);
            if (productImage == null)
                throw new Exception($"not exits in Image List");

            await _Istoreservice.DeleteFileAsync(productImage.ImagePath);
            data.ProductImages.Remove(productImage);
            return await data.SaveChangesAsync();
        }

        public Task<RoleViewModel> roleViewModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResult<bool>> Update(ProductEditRequest request)
        {
            var product = await data.Products.FindAsync(request.Proid);
            var productTranslation = await data.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Proid
             && x.LangueId == request.LangId);
            if (product == null) throw new ShopException("Can not find Product " + request.Proid);
            if (productTranslation == null || productTranslation != null)
            {
                productTranslation.Name = request.Name;
                productTranslation.SeoAlias = request.SeoAlias;
                productTranslation.Description = request.Description;
                productTranslation.SeoTitle = request.SeoTitle;
                productTranslation.Details = request.Details;
                productTranslation.LangueId = request.LangId;
            }

            if (request.ThumbnaiImage != null)
            {
                var thumnailImage = await data.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Proid);
                if (thumnailImage != null)
                {
                    thumnailImage.FileSize = request.ThumbnaiImage.Length;
                    thumnailImage.ImagePath = await this.SaveFile(request.ThumbnaiImage);
                    data.ProductImages.Update(thumnailImage);
                }
                else
                {
                    product.ProductImages = new List<ProductImage>()
                    {
                        new ProductImage()
                        {
                         Caption = ConnectionStringcs.Na,
                        IsDefault = true,
                        SortOrder = 1,
                        DateCreate = DateTime.Now,
                        FileSize = request.ThumbnaiImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnaiImage),
                        },
                    };
                }
            }
            data.Products.Update(product);
            var result = await data.SaveChangesAsync(); // return 1 if success
            if (result != 0)
            {
                return new APISuccessResult<bool>();
            }

            return new APIFailResult<bool>();
        }

        public async Task<int> UpdateImage(int productId, int ImageId, ImageEditRequest request)
        {
            var productImage = await data.ProductImages.FindAsync(ImageId);
            if (productImage == null)
                //return -1;
                throw new ShopException("Image not exits!");

            if (request.ImagePath != null)
            {
                productImage.ImagePath = request.ImagePath;
                productImage.ThumbnailFile = request.ImageFile;
                productImage.FileSize = request.ImageFile.Length;
                productImage.IsDefault = request.IsDefault;
                productImage.SortOrder = request.SortOrder;
            }
            data.ProductImages.Update(productImage);
            await data.SaveChangesAsync();

            return productImage.Id;
        }

        public async Task<bool> UpdatePrice(int ProductId, decimal newPrice)
        {
            var product = await data.Products.FindAsync(ProductId);
            if (product == null) throw new ShopException("Can not find Product " + ProductId);
            product.Price = newPrice;
            return await data.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int ProductId, int newStock)
        {
            var product = await data.Products.FindAsync(ProductId);
            if (product == null) throw new ShopException("Can not find Product " + ProductId);
            product.Stock += newStock;
            return await data.SaveChangesAsync() > 0;
        }

        public async Task UpdateViewCount(int ProductId)
        {
            var resurl = await data.Products.FindAsync(ProductId);
            if (resurl != null)
            {
                resurl.ViewCount += 1;
                await data.SaveChangesAsync();
            }
        }

        Task<List<ProductViewModel>> IManageProductService.GetAll()
        {
            throw new NotImplementedException();
        }

        private const string User_Content_Folder_Name = "user_content";

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{(originalFileName)}";
            await _Istoreservice.SaveFileAsync(file.OpenReadStream(), fileName);
            return $"/{User_Content_Folder_Name}/{fileName}";
        }

        //private const string User_Content_Folder_Name = "user_content";
        //private readonly IWebHostEnvironment webHostEnvironment;

        //private string GetImageIfNoAvailable()
        //{
        //    var imagePath = Path.Combine(webHostEnvironment.WebRootPath, User_Content_Folder_Name);
        //    var fileName = $"/{imagePath}/No.jpg";
        //    return fileName;
        //}
    }
}