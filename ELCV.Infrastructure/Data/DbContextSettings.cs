using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ELCV.Core.Handlers;
namespace ELCV.Infrastructure.Data
{
    public class DbContextSettings
    {
        private readonly JSonFilesHandler jsonFileHandler;

        public DbContextSettings(JSonFilesHandler jsonFileHandler)
        {
            this.jsonFileHandler = jsonFileHandler;
        }
        public IConfigurationRoot SetConfigurationSettings()
        {
            Dictionary<string, string> DataFileSettings = GetDataFileSettings();

            string startUpDirectoryAbsolutePath = GetProjectDirectoryPath(DataFileSettings["ProjectDirectoryPath"]);
            var configuration = new ConfigurationBuilder()
           .SetBasePath(startUpDirectoryAbsolutePath)
           .AddJsonFile(DataFileSettings["ConfigFileName"])
           .Build();
            return configuration;
        }

        private static string GetProjectDirectoryPath(string startUpProjectDirectoryName)
        {
            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string startUpDirectoryAbsolutePath = solutionDirectory + Path.DirectorySeparatorChar + startUpProjectDirectoryName;
            return startUpDirectoryAbsolutePath;
        }

        public Dictionary<string, string> GetDataFileSettings()
        {
           
            var directoryPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Data";
            var fileName = "dataconfig.json";
            Dictionary<string, string> DataFileSettings = jsonFileHandler.GetJsonFileData(directoryPath, fileName);
            return DataFileSettings;
        }

       

    }
}
