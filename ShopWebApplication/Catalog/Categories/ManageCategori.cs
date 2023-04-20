using Microsoft.EntityFrameworkCore;
using ShopWebData.DbContextData;
using ShopWebData.Entities;
using ShopWebModels.Catalog.Categories;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Catalog.Categories
{
    public class ManageCategori : IManageCategori
    {
        private readonly TeduDbContext _dbContext;

        public ManageCategori(TeduDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<List<CategoryViewModel>> GetAllCategory(int cateID)
        //{
        //    var querry = from c in _dbContext.Categories
        //                     //join pc in _dbContext.ProductCategory on c.Id equals pc.CategoryId

        //                 join pic in _dbContext.ProductCategory on c.Id equals pic.CategoryId
        //                 join p in _dbContext.Products on pic.ProductId equals p.Id
        //                 where pic.CategoryId == cateID
        //                 select new { c, pic, p };
        //    var categories = await querry.Select(x => new CategoryViewModel()
        //    {
        //        CateId = x.c.Id,
        //        CateName = x.c.CateName
        //    }).ToListAsync();
        //    return categories;
        //}
        public async Task<List<CategoriSelected>> GetAllCategory()
        {
            var querry = await _dbContext.Categories.Select(x => new CategoriSelected()
            {
                CateId = x.Id,
                CateName = x.CateName,
                cateSelected = false
            }).ToListAsync();

            return querry;
        }

        public async Task<APIResult<bool>> AssignCategori(int proId, CategoriAssign request)
        {
            var product = _dbContext.Products.Where(x => x.Id == proId);
            if (product == null)
                return new APIFailResult<bool>($"{proId} does not exits!!");

            var removeCateSelected = request.Selected.Where(x => x.cateSelected == false).ToList();

            if (removeCateSelected.Count > 0)
            {
                foreach (var item in removeCateSelected)
                {
                    var categories = await _dbContext.ProductCategory.FirstOrDefaultAsync(x => x.CategoryId == item.CateId &&
                     x.ProductId == proId);
                    if (categories != null)
                        _dbContext.ProductCategory.Remove(categories);
                }
            }

            var addCateSelected = request.Selected.Where(x => x.cateSelected == true).ToList();
            if (addCateSelected.Count > 0)
            {
                foreach (var item in addCateSelected)
                {
                    var categories = await _dbContext.ProductCategory.FirstOrDefaultAsync(x => x.CategoryId == item.CateId &&
                    x.ProductId == proId);
                    if (categories == null)
                        await _dbContext.ProductCategory.AddAsync(new ProductInCaterogy
                        {
                            CategoryId = item.CateId,
                            ProductId = proId
                        });
                }
            }
            await _dbContext.SaveChangesAsync();
            return new APISuccessResult<bool>();
        }

        public async Task<CategoriAssign> GetCateByProductId(int proId)
        {
            var categories = from c in _dbContext.Categories
                             join pic in _dbContext.ProductCategory on c.Id equals pic.CategoryId
                             where pic.ProductId == proId
                             select new { c, pic };
            if (categories == null)
                return null;

            var result = await categories.Select(x => new CategoriSelected
            {
                CateId = x.c.Id,
                CateName = x.c.CateName,
                cateSelected = true,
            }).ToListAsync();

            CategoriAssign data = new CategoriAssign()
            {
                ProId = proId,
                Selected = result
            };
            return data;
        }
    }
}