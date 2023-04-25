using ShopWebModels.Catalog.Categories;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPIApp.Service.Categories
{
    public interface ICategoriesService
    {
        Task<List<CategoriSelected>> GetAllCategory();

        Task<APIResult<bool>> AssignCategori(int proId, CategoriAssign request);

        Task<CategoriAssign> GetCateByProductId(int proId);
    }
}