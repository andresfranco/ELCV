using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ELCV.Core.Handlers;
using System.Collections.Generic;
using System;

namespace ELCVTest
{
    [TestClass]
    public class JsonFilesHandlerTest
    {

        private readonly JSonFilesHandler Handler;
        public JsonFilesHandlerTest()
        {
            Handler = new JSonFilesHandler();
        }

        [TestMethod]
        public void GetFilePathTest()
        {
            string folderSeparator = Path.DirectorySeparatorChar.ToString();
            string fileDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string fileName = "dataconfig.json";
            string expected = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + folderSeparator+ "dataconfig.json";
            string filePath = Handler.GetfilePath(fileDirectoryPath, fileName);

            Assert.AreEqual(expected, filePath);

        }
        [TestMethod]
        public void GetJsonFileDataTest()
        {
            string folderSeparator = Path.DirectorySeparatorChar.ToString();
     
            string fileDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + folderSeparator + "Infrastructure" + folderSeparator+ "Data";
            string fileName = "dataconfig.json";
            Dictionary<string, string> result = Handler.GetJsonFileData(fileDirectoryPath, fileName);
            
            //Has to be the same Content of dataconfig.json
            var expected = new Dictionary<string, string>()
                { { "ConfigFileName","appsettings.json"},{ "ProjectDirectoryPath","ELCV.UI"} ,{ "DBConnectionStringName","ELCVConnectionString"} };
            CollectionAssert.AreEquivalent(expected, result);
        }

        
       

    }
}
