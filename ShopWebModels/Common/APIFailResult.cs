using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Common
{
    public class APIFailResult<T> : APIResult<T>
    {
        public string[] ValidationError;

        public APIFailResult(string mess)
        {
            Success = false;
            Message = mess;
        }

        public APIFailResult(string[] validationError)
        {
            Success = false;
            ValidationError = validationError;
        }
    }
}