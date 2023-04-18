using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Common
{
    public class PageResult<T>
    {
        public List<T> Item { get; set; }
        public int TotalRecord { get; set; }
    }
}