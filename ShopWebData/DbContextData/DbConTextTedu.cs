using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWebData.DbContextData;
using ShopWebException.Common;

namespace ShopWebData.DbContextData
{
    public class DbConTextTeduFactory : IDesignTimeDbContextFactory<TeduDbContext>
    {
        public TeduDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot iconfiguration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("jsconfig1.json").Build();

           // có trên doc
           var optionBuilder = new DbContextOptionsBuilder<TeduDbContext>();
            optionBuilder.UseSqlServer(iconfiguration.GetConnectionString(ConnectionStringcs.Connect)); // lấy đường dẫn chứa file có connection string
            return new TeduDbContext(optionBuilder.Options);
        }
    }
}
