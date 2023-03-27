using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filePath)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filePath);
        }
    }
}
