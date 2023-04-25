using Microsoft.EntityFrameworkCore;
using ShopWebData.DbContextData;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Catalog.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Catalog.Slide
{
    public class SlideServiceImp : ISlideService
    {
        private readonly TeduDbContext _dbcontext;

        public SlideServiceImp(TeduDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<SlideViewModel>> GetAll()
        {
            var resurl = await _dbcontext.Slide.Select(x => new SlideViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                status = x.status,
                Url = x.Url,
                Image = x.Image,
                SortOrder = x.SortOrder
            }).OrderBy(x => x.SortOrder).ToListAsync();

            return resurl;
        }

        public async Task<List<ProductViewModel>> GetFeartureProduct(int PageSize)
        {
            var query = from p in _dbcontext.Products
                        join pt in _dbcontext.ProductTranslations on p.Id equals pt.ProductId
                        join pc in _dbcontext.ProductCategory on p.Id equals pc.ProductId into ppc
                        from pc in ppc.DefaultIfEmpty()
                        join pi in _dbcontext.ProductImages.Where(x => x.IsDefault == true) on p.Id equals pi.ProductId //into pp
                                                                                                                        // from pi in pp.DefaultIfEmpty()
                        join c in _dbcontext.Categories on pc.CategoryId equals c.Id into cpc
                        from c in cpc.DefaultIfEmpty()
                        where p.IsFeatured == true
                        select new { p, pc, c, pi };

            var result = await query.Skip(PageSize).OrderByDescending(x => x.p.DateCreated).Select(x => new ProductViewModel()
            {
                Id = x.p.Id,
                CategoriId = x.c.Id,
                cateName = x.c.CateName,
                Price = x.p.Price,
                OriginalPrice = x.p.OriginalPrice,
                Description = x.p.Description,
                Stock = x.p.Stock,
                ProductName = x.p.ProductName,
                IsFeatured = x.p.IsFeatured,
                DateCreated = x.p.DateCreated,
                ViewCount = x.p.ViewCount,
                ThumnailFile = x.pi.ImagePath
            }).ToListAsync();

            return result;
        }

        public async Task<List<ProductViewModel>> GetLatestProduct(int PageSize)
        {
            var query = from p in _dbcontext.Products
                        join pt in _dbcontext.ProductTranslations on p.Id equals pt.ProductId
                        join pc in _dbcontext.ProductCategory on p.Id equals pc.ProductId into ppc
                        from pc in ppc.DefaultIfEmpty()
                        join pi in _dbcontext.ProductImages.Where(x => x.IsDefault == true) on p.Id equals pi.ProductId //into pp
                                                                                                                        // from pi in pp.DefaultIfEmpty()
                        join c in _dbcontext.Categories on pc.CategoryId equals c.Id into cpc
                        from c in cpc.DefaultIfEmpty()
                        select new { p, pc, c, pi };

            var result = await query.Skip(PageSize).OrderByDescending(x => x.p.DateCreated).Select(x => new ProductViewModel()
            {
                Id = x.p.Id,
                CategoriId = x.c.Id,
                cateName = x.c.CateName,
                Price = x.p.Price,
                OriginalPrice = x.p.OriginalPrice,
                Description = x.p.Description,
                Stock = x.p.Stock,
                ProductName = x.p.ProductName,
                IsFeatured = x.p.IsFeatured,
                DateCreated = x.p.DateCreated,
                ViewCount = x.p.ViewCount,
                ThumnailFile = x.pi.ImagePath
            }).ToListAsync();

            return result;
        }
    }
}