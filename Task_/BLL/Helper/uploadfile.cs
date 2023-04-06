
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helper
{
    public static class uploadfile
    {
        //Function To Upload File and remove File
        //For Add Using Parameter Folder ,Request
        //For Update Using Parameter Folder,Request,Path
        //For Delete Using Paratmeter Path
        public static string upload<T>(this T Object,string folder, IFormFile request=null, string path = null)
        {
            if (!string.IsNullOrEmpty(path))
            {
                FileInfo delete = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(),
                       "wwwroot/Files", folder, path));
                    delete.Delete();      
            }
            if (request != null)
            {
                var fileName = ContentDispositionHeaderValue.Parse(request.ContentDisposition).FileName.Trim('"');
                fileName = fileName.Replace(" ", String.Empty);
                var folderName = Path.Combine("wwwroot/Files", folder);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (pathToSave is null)
                {
                    Directory.CreateDirectory(pathToSave);
                }
                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    request.CopyTo(stream);
                }
                return fileName;
            }else
            {
                return String.Empty;
            }

          
        }
        public static bool ChckFileExtension<T>(this T Object, IFormFile postedFile, string fileType)
        {
            var postedFileExtension = Path.GetExtension(postedFile.FileName);

            if (fileType=="profilePicture")
            {
                if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                return true;
            }
            else if (fileType=="CV")
            {
                if (!string.Equals(postedFileExtension, ".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
