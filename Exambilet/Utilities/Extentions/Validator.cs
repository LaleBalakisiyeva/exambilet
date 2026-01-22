using Exambilet.Utilities.Enums;
using Microsoft.AspNetCore.Http;

namespace Exambilet.Utilities.Extentions
{
    public static class Validator
    {
        public static bool ValidateType(this IFormFile fromFile,string type)
        {
            if (fromFile.ContentType.Contains(type))
            {
                return true;
            }
            return false;

        }

        public static bool ValidateSize(this IFormFile fromFile,FileSize fileSize,int size)
        {
            switch (fileSize)
            {
                case FileSize.KB:
                    return fromFile.Length > size * 1024;
                case FileSize.MB:
                    return fromFile.Length > size * 1024*1024;
                case FileSize.GB:
                    return fromFile.Length > size * 1024*1024*1024;
            }
            return false;
        }

        public async static Task<string> CreateFile(this IFormFile fromFile,params string[] roots)
        {
            string fileName = String.Concat(Guid.NewGuid().ToString(), fromFile.FileName);
            string path = String.Empty;
            for(int i = 0; i < roots.Length; i++)
            {
                path=Path.Combine(path, roots[i]);
            }

            path = Path.Combine(path, fileName);
            using(FileStream fileStream=new(path, FileMode.Create))
            {
                await fileStream.CopyToAsync(fileStream);
            }

            return fileName;
        }
    }
}
