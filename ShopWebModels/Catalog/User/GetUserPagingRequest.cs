﻿using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.User
{
    public class GetUserPagingRequest : PagingRequestPage
    {
        public string Keyword { get; set; }
    }
}