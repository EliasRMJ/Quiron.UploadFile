using Microsoft.AspNetCore.Http;

namespace Quiron.UploadFile
{
    public interface IUpload
    {
        Task<string> File(IFormFile? file, params string[] folders);
        Task<string[]> Files(IFormFile[]? files, params string[] folder);
    }
}