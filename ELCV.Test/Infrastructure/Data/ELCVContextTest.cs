using Microsoft.VisualStudio.TestTools.UnitTesting;
using ELCV.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ELCV.Test.Infrastructure.Data
{ 
    [TestClass]
    public class ELCVContextTest
    {
        
        private readonly ELCVContext context;

        public ELCVContextTest()
        {
            context = new ELCVContext(GetcontextOptions().Options);
        }

        [TestMethod]
        public void TestDatabaseConnection()
        {
            Assert.IsTrue(context.Database.CanConnect());
        }

        public DbContextOptionsBuilder<ELCVContext> GetcontextOptions()
        {
            string directoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/../../ELCV.UI/appsettings.json";
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                         .AddJsonFile(directoryPath)
                                                                         .Build();
            var builder = new DbContextOptionsBuilder<ELCVContext>();
            var connectionString = configuration.GetConnectionString("ELCVConnectionString");
            builder.UseSqlServer(connectionString);
            return builder;
        }



    }
}
