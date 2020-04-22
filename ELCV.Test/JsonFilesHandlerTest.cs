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
            var folderSeparator = Path.DirectorySeparatorChar;
            var fileDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + folderSeparator + "Data";

            var fileName = "dataconfig.json";
            string expected = "C:" + folderSeparator + "Projects" + folderSeparator + "ELCV" + folderSeparator + "ElCV"
                               + folderSeparator + "ELCV.Test" + folderSeparator
                              + "Data" + folderSeparator + "dataconfig.json";
            string filePath = Handler.GetfilePath(fileDirectoryPath, fileName);

            Assert.AreEqual(expected, filePath);

        }
        [TestMethod]
        public void GetJsonFileDataTest()
        {
            var folderSeparator = Path.DirectorySeparatorChar;
            var fileDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + folderSeparator + "Data";
            var fileName = "dataconfig.json";
            Dictionary<string, string> result = Handler.GetJsonFileData(fileDirectoryPath, fileName);
            var expected = new Dictionary<string, string>()
                { { "ConfigFileName","appsettings.json"},{ "ProjectDirectoryPath","ELCV.UI"} ,{ "DBConnectionStringName","ELCVConnectionString"} };
            CollectionAssert.AreEquivalent(expected, result);
        }

    }
}
