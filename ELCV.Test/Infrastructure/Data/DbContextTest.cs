using ELCV.Infrastructure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Test.Infrastructure.Data
{ 
    [TestClass]
    public class DbContextTest
    {
        private readonly ELCVContext dbContext;

        public DbContextTest()
        {
            dbContext = new ELCVContext();
        }

        [TestMethod]
        public  void TestDatabaseConnection()
        {
            Assert.IsTrue(dbContext.Database.CanConnect());
        }
    }
}
