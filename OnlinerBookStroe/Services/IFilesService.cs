
namespace OnlineBookStroe.Services
{
    public interface IFilesService
    {
        Task<string> UploadFiles(IFormFile file);
        Task<byte[]> GetFiles(string imageName);
    }
}