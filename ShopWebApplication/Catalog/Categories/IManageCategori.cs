using ShopWebModels.Catalog.Categories;
using ShopWebModels.Common;
using ShopWebModels.WebApp.CategoriProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Catalog.Categories
{
    public interface IManageCategori
    {
        Task<List<CategoriSelected>> GetAllCategory();

        Task<APIResult<bool>> AssignCategori(int proId, CategoriAssign request);

        Task<CategoriAssign> GetCateByProductId(int proId);

        Task<CategoryViewModel> GetProductByCateId(int cateID, int langId);
    }
}