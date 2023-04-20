using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWebModels.Common;

namespace ShopWebModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestPage
    {
        public string Key { get; set; }

        public int langugeId { get; set; }
        public int? Categori { get; set; }
        //  public List<int> CategoryId { get; set; }
    }
}