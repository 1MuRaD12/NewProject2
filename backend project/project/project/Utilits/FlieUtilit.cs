using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace project.Utilits
{
    public static class FlieUtilit
    {
        public static async Task<string> FileCreate(this IFormFile formFile, string root, string folder)
        {
            string filestream = Guid.NewGuid() + formFile.FileName;
            string path = Path.Combine(root, folder);
            string fullpath = Path.Combine(path, filestream);

            using (FileStream file = new FileStream(fullpath,FileMode.Create) )
            {
                await formFile.CopyToAsync(file);
            }
            return filestream;
        }
    }
}
