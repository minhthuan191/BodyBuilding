using Microsoft.AspNetCore.Http;

namespace BodyBuildingApp.Utils.Interface
{
    public interface IUploadFileService
    {
        public bool CheckFileSize(IFormFile file, int limit);
        public bool CheckFileExtension(IFormFile file);
        public string Upload(IFormFile file);
    }
}
