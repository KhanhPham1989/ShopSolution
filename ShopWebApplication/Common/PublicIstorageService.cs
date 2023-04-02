using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Common
{
    public class PublicIstorageService : IStoreService
    {
        private readonly string _userContentFolder;
        private const string User_Content_Folder_Name = "user_content";

       //vi day la 1 library chu ko phai app nen add vao de nhan dien nang cap ngang vs 1 app dung dc Iwebhost trong Edit Project File
        public PublicIstorageService(IWebHostEnvironment webHostEnvironment)
        {
            _userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, User_Content_Folder_Name);
        }
        public string GetFileUrl(string fileName)
        {
            return $"/{User_Content_Folder_Name}/{fileName}";
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if(File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath)); 
            }
        }


        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }
    }
}
