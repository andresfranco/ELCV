using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ELCV.Core.Handlers
{
    public class JSonFilesHandler
    {
        public Dictionary<string,string> GetJsonFileData(string directoryPath ,string fileName)
        {
            var filePath = GetfilePath(directoryPath,fileName);
            var jsonData = File.ReadAllText(filePath);
            Dictionary<string, string> DataFileSettings = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            return DataFileSettings;
        }

        public string GetfilePath(string directoryPath,string fileName)
        {
            string fullPath = directoryPath + Path.DirectorySeparatorChar + fileName;
            return fullPath;
        }

       
    }
}
