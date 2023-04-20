using ShopWebModels.Catalog.Categories;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Service.Categories
{
    public interface ICategoriesService
    {
        Task<List<CategoriSelected>> GetAllCategory();

        Task<APIResult<bool>> AssignCategori(int proId, CategoriAssign request);

        Task<CategoriAssign> GetCateByProductId(int proId);
    }
}