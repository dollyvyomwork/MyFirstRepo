using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RealEststeRelar.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }
        public void MoveFile()
        {
            // string fileName = "Desert.jpg";
            string sourcePath = "D:\\MLS1";
            string destPath = "D:\\RelarImages";

            string destFile = "";

            //Get all the files from a directory
            var files = Directory.GetFiles(sourcePath);


            //Iterate through all the files of source folder and move them to the destination folder
            //foreach (var file in files)
           // {
            //    destFile = System.IO.Path.Combine(destPath, file.Substring(8));

                // To move a file or folder to a new location
            //    System.IO.File.Move(file, destFile);

                //To delete file from source folder
                //System.IO.File.Delete(file);
          //  }

            Image image = Image.FromFile(@"D:\MLS1\Koala.jpg");
            byte[] buffer = ImageToByteArray(image);
            string md5 = GetMd5Hash(buffer);
        }

        //Create MD5 hash of an image
        static string GetMd5Hash(byte[] buffer)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] data = md5Hasher.ComputeHash(buffer);

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        //Converts an image to Byte array
        static byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Bmp);
            return ms.ToArray();
        }
    }
}