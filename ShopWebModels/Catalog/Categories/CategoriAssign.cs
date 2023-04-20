using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.Categories
{
    public class CategoriAssign
    {
        public int ProId { get; set; }
        public List<CategoriSelected> Selected { get; set; } = new List<CategoriSelected>();
    }
}