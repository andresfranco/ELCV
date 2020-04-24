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

        public string GetProjectDirectoryPath(string startUpProjectDirectoryName)
        {
            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string startUpDirectoryAbsolutePath = solutionDirectory + Path.DirectorySeparatorChar + startUpProjectDirectoryName;
            return startUpDirectoryAbsolutePath;
        }

        public Dictionary<string, string> GetDataFileSettings()
        {
            JSonFilesHandler jsonFileHandler = new JSonFilesHandler();
            string separator = Path.DirectorySeparatorChar.ToString();
            string projectDirectoryPath = "ELCV.Infrastructure";
            string dataFolderName = "Data";
            string fileName = "dataconfig.json";
            string fileFullPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName
                                  + separator + projectDirectoryPath + separator + dataFolderName;
            Dictionary<string, string> DataFileSettings = jsonFileHandler.GetJsonFileData(fileFullPath, fileName);
            return DataFileSettings;
        }

    }
}
