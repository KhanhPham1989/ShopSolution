using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWebApplication.Common;
using ShopWebData.DbContextData;
using ShopWebData.Entities;
using ShopWebException.TeduException;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


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

        public async Task<int> Create(ProductCreateRequest request)
        {
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
                ProductTranslations = new List<ProductTranslation>
                {
                    new ProductTranslation
                    {
                        LangueId = request.langId,
                        Description = request.Description,
                        Details = request.Details,
                        SeoAlias = request.SeoAlias
                    }
                }
            };
            // Save Image
            // Kiem tra trong object gui toi co hinh anh hya ko
            if(request.ThumbnaiImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage
                    {
                        Caption = request.CaptionImage,
                        DateCreate = DateTime.Now,
                        FileSize = request.ThumbnaiImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnaiImage),
                        IsDefault = true,
                        SortOrder = 1,
                    }
                };
            }

            data.Products.Add(product);
            await data.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productId)
        {
            var product = await data.Products.FindAsync(productId);
            if (product == null) throw new Exception("Can not find Product" + productId);
            var images = data.ProductImages.Where(x => x.ProductId == productId);
            if (images != null )
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


        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            // select and join
            var query = from p in data.Products
                          join pt in data.ProductTranslations on p.Id equals pt.ProductId
                          join pic in data.ProductCategory on p.Id equals pic.ProductId
                          join c in data.Categories on pic.CategoryId equals c.Id
                          select new { p, pt, pic};

            // filter
            if (!string.IsNullOrEmpty(request.Key))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Key));
            }
            if (request.CategoryId.Count >  0)
                query = query.Where(x => request.CategoryId.Contains(x.pic.CategoryId));
            // paging
            var totalRow = await query.CountAsync();
            var resurl = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductViewModel() 
                { 
                   Id = x.p.Id,
                   ProductName = x.p.ProductName,
                   Price = x.p.Price,
                   OriginalPrice = x.p.OriginalPrice,
                   Description = x.p.Description
                }).ToListAsync();

            // select and projection
            var pageRecord = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Item = resurl
            };
            return pageRecord;
        }

        public async Task<int> Update(ProductEditRequest request)
        {
            var product = await data.Products.FindAsync(request.Proid);
            var productTranslation = await data.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Proid
             && x.LangueId == request.LangId);
            if(product == null || productTranslation == null) throw new ShopException("Can not find Product " + request.Proid);
            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.Description = request.Description;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Details = request.Details;
            if (request.ThumbnaiImage != null)
            {
                var thumnailImage = await data.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Proid);
                if(thumnailImage != null)
                {
                    thumnailImage.FileSize = request.ThumbnaiImage.Length;
                    thumnailImage.ImagePath = await this.SaveFile(request.ThumbnaiImage);
                    data.ProductImages.Update(thumnailImage);
                }
            }
            return await data.SaveChangesAsync(); // return 1 if success
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
            if(resurl != null)
            {
                resurl.ViewCount += 1;
                await data.SaveChangesAsync();
                
            }
            
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _Istoreservice.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public Task<int> AddImages(int ProductId, List<IFormFile> productImages)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImages(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool Isdefault)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductViewModel> GetById(int productId,int languageID)
        {
            var product = await data.Products.FindAsync(productId);
            var productTranslation = await data.ProductTranslations.
                    FirstOrDefaultAsync(x => x.ProductId == productId && x.LangueId == languageID);
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
    }
}
