using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Common
{
    public class PagingRequestPage : GetTokenRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}