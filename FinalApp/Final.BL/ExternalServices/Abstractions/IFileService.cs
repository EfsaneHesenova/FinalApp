using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.ExternalServices.Abstractions
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile imageFile, string envPath, string[] allowedFileExtensions);
        void DeleteFile(string fileNameWithExtension, string envPath);
    }
}
