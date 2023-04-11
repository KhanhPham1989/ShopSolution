using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Common
{
    public class APISuccessResult<T> : APIResult<T>
    {
        public APISuccessResult(T objresult)
        {
            Success = true;
            ObjResult = objresult;
        }

        public APISuccessResult()
        {
            Success = true;
        }
    }
}