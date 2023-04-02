﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWebModels.Common;

namespace ShopWebModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestPage
    {
        public string Key { get; set; }

        public int? CategoryId { get; set; }
    }
}
