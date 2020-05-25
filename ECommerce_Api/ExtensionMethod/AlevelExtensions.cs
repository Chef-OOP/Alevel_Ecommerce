using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.ExtensionMethod
{
    public static class AlevelExtensions
    {
        public async  static Task<string> ReadFile(IFormFile file,string road)
        {
            var newFile =
                Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path =
                Path.Combine(Directory.GetCurrentDirectory(),
                road + newFile);
            var stream =
                new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return path;

            //var newFileLogoName =
            //        Guid.NewGuid() + Path.GetExtension(fileLogo.FileName);
            //var pathLogo =
            //    Path.Combine(Directory.GetCurrentDirectory(),
            //    "wwwroot/img/masterCategory/" + newFileLogoName);
            //var streamLogo =
            //    new FileStream(pathLogo, FileMode.Create);
            //await fileLogo.CopyToAsync(streamLogo);
            //masterCategoryDto.Logo = pathLogo;

        }
    }
}
