using Microsoft.VisualStudio.TestTools.UnitTesting;
using ELCV.Core.Handlers;
using System.IO;

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

            var fileDirectoryPath = Directory.GetCurrentDirectory()+"/Data";

            var fileName = "dataconfig.json";
            string expected = "C:\\Projects\\ELCV\\ElCV\\ELCVTest\\Data\\dataconfig.json";
            string filePath = Handler.GetfilePath(fileDirectoryPath, fileName);

            Assert.AreEqual(expected,"");


        }
    }
}
