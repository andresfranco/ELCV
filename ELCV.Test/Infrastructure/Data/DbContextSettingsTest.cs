using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ELCV.Core.Handlers;
using System.Collections.Generic;
using System;
using ELCV.Infrastructure.Data;
using System.Reflection;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace ELCV.Test.Infrastructure.Data
{
    [TestClass]
    public class DbContextSettingsTest
    {
        private readonly DbContextSettings dbContextSettings;
        private JSonFilesHandler jsonFileHandler;

        public DbContextSettingsTest()
        {
            dbContextSettings = new DbContextSettings();
            jsonFileHandler = new JSonFilesHandler();
        }

        [TestMethod]
        public void GetProjectDirectoryPathTest()
        {
            string startUpProjectDirectoryName = "ELCV.UI";
          
            string folderSeparator = Path.DirectorySeparatorChar.ToString();

            string expectedInfrastructureProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + folderSeparator + startUpProjectDirectoryName;
            string result = dbContextSettings.GetProjectDirectoryPath(startUpProjectDirectoryName);
            Assert.AreEqual(expectedInfrastructureProjectPath, result);
            
        }

        [TestMethod]
        public void GetDataFileSettings()
        {

            var DataFileSettings = GetConfigData();

            var expected = new Dictionary<string, string>()
                { { "ConfigFileName","appsettings.json"},{ "ProjectDirectoryPath","ELCV.UI"} ,{ "DBConnectionStringName","ELCVConnectionString"} };
            
            CollectionAssert.AreEquivalent(expected, DataFileSettings); 
 

        }
        [TestMethod]
        public void SetConfigurationSettingsTest()
        {
            Dictionary<string, string> DataFileSettings = GetConfigData();

            string startUpProjectDirectoryName = "ELCV.UI";

            string folderSeparator = Path.DirectorySeparatorChar.ToString();

            string expectedInfrastructureProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin",string.Empty).Replace("\\ELCV.Test",string.Empty) + folderSeparator + startUpProjectDirectoryName;
            var configurationexpected = new ConfigurationBuilder()
           .SetBasePath(expectedInfrastructureProjectPath)
           .AddJsonFile("appsettings.json")
           .Build();
            Assert.IsNotNull(configurationexpected);
        }
        
        public Dictionary<string, string> GetConfigData()
        {
            JSonFilesHandler jsonFileHandler = new JSonFilesHandler();
            string separator = Path.DirectorySeparatorChar.ToString();
            string projectDirectoryPath = "ELCV.Infrastructure";
            string dataFolderName = "Data";
            string fileName = "dataconfig.json";
            //Path change for testing
            string fileFullPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName
                                  + separator + projectDirectoryPath + separator + dataFolderName;
            Dictionary<string, string> dataFileSettings = jsonFileHandler.GetJsonFileData(fileFullPath, fileName);
            return dataFileSettings;
        }


    }
}
