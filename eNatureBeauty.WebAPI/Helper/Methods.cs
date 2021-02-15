using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace eNatureBeauty.WebAPI.Helper
{
    public class Methods
    {
        public static string GetFilePathJsonData(string fileName)
        {
            string exeFile = AppDomain.CurrentDomain.BaseDirectory;
            string exeDir = Path.GetDirectoryName(exeFile);
            string fullPath = exeDir.ToString() + "/DataSeed/" + fileName;
            return fullPath;
        }
        public static List<T> LoadJsonFromFile<T>(string fileName)
        {
            using (StreamReader r = new StreamReader(GetFilePathJsonData(fileName)))
            {
                string json = r.ReadToEnd();
                List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
                return items;
            }
        }
    }
}
