using Microsoft.EntityFrameworkCore;
using ShopWebData.DbContextData;
using ShopWebData.Entities;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly TeduDbContext data;

        public PublicProductService(TeduDbContext _data)
        {
            data = _data;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var query = from p in data.Products
                        join pt in data.ProductTranslations on p.Id equals pt.ProductId
                        join pic in data.ProductCategory on p.Id equals pic.ProductId
                        join c in data.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            var resurl = await query
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    ProductName = x.p.ProductName,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Description = x.p.Description,
                    SeoAlias = x.pt.SeoAlias,
                    TranslationName = "ABC",
                    SeoDescription = "ABC",
                    Stock = x.p.Stock,
                    SeoTitle = x.pt.SeoTitle,
                    ViewCount = x.p.ViewCount,
                    DateCreated = x.p.DateCreated
                }).ToListAsync();
            return resurl;
        }

        // tra ve list cua ProductViewModel
        public async Task<PageResult<ProductViewModel>> GetAllByCategoryById(int langId, GetPublicProductPagingRequest request)
        {
            // select and join
            var query = from p in data.Products
                        join pt in data.ProductTranslations on p.Id equals pt.ProductId
                        join pic in data.ProductCategory on p.Id equals pic.ProductId
                        join c in data.Categories on pic.CategoryId equals c.Id
                        where pt.LangueId == langId
                        select new { p, pt, pic };

            // filter
            //if (!string.IsNullOrEmpty(request.key))
            //{
            //    query = query.Where(x => x.pt.Name.Contains(request.key));
            //}
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
                query = query.Where(x => request.CategoryId == (x.pic.CategoryId));
            // paging
            var totalRow = await query.CountAsync(); // tra ve so luong dong
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
            var pageRecord = new PageResult<ProductViewModel>() // tao 1 class tra ve cho view 2 gia tri
            {
                TotalRecords = totalRow,
                Item = resurl
            };
            return pageRecord;
        }
    }
}