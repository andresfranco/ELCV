using ELCV.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json.Linq;
using ELCV.Core.Handlers;

namespace ELCV.Infrastructure.Data
{
        public class DbContextFactory : IDesignTimeDbContextFactory<ELCVContext>
        {

            public ELCVContext CreateDbContext(string[] args)
            {
                string configFilePath = Directory.GetParent(Directory.GetCurrentDirectory()) + "/ELCV.UI/appsettings.json";
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                             .AddJsonFile(configFilePath)
                                                                             .Build();
                var builder = new DbContextOptionsBuilder<ELCVContext>();
                var connectionString = configuration.GetConnectionString("ELCVConnectionString");
                builder.UseSqlServer(connectionString);
                return new ELCVContext(builder.Options);
            }
        }
 
}
