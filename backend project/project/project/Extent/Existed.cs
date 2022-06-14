using Microsoft.AspNetCore.Http;

namespace project.Extent
{
    public static class Existed
    {
        public static bool Isexsted(this IFormFile formFile, int mb)
        {
            return formFile.ContentType.Contains("image") && formFile.Length < mb * 1024 * 1024;
        }
    }
}
