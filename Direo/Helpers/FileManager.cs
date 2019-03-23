using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Helpers
{
    public class FileManager
    {
        public static string Upload(string FileRaw, string ext)
        {
            var imageDataByteArray = Convert.FromBase64String(FileRaw);

            var imageDataStream = new MemoryStream(imageDataByteArray)
            {
                Position = 0
            };

            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + ext;

            var path = Path.Combine(
                       Directory.GetCurrentDirectory(), "wwwroot/Uploads",
                       filename);

            FileStream file = new FileStream(path, FileMode.Create, System.IO.FileAccess.Write);

            imageDataStream.WriteTo(file);
            return filename;
        }

        public static bool Delete(string FileName)
        {
            var path = Path.Combine(
                          Directory.GetCurrentDirectory(), "wwwroot/Uploads",
                          FileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }

            return false;
        }
    }
}
