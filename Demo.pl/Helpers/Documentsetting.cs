using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Demo.pl.Helpers
{
    public static class Documentsetting
    {
        //upload
        //delete
        public static string uploadfile(IFormFile file ,string foldername)
        {
            //1.get path
            string folderpath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\files" ,foldername);
           //2.get file name and make it unique
           string filename =$"{ file.FileName}";
            //3.get file path [folder path + file name]
            string filepath = Path.Combine(folderpath,filename);
            //4.save file as streams
            using var fs = new FileStream(filepath , FileMode.Create);
            file.CopyTo(fs);
            //5.return file name
            return filename;

        }
        //delete file 
        public static void Deletefile(string filename , string foldername)
        {
            //1.get file path
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", foldername, filename);
            //check if the file exist or not
            if (File.Exists(filepath))
            {
                //if exist delete it

                File.Delete(filepath);
            }

        }
    }
}
