using System.IO;
using System.IO.Compression;

namespace Ex06.ZipExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            var zipFile = "../../../myzip.zip";
            var file = "../../../copyMe.png";

            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        }
    }
}
