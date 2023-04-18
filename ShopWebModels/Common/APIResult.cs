using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Common
{
    public class APIResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T ObjResult { get; set; }
    }
}