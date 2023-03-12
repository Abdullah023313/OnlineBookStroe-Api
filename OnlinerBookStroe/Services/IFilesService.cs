namespace OnlineBookStroe.Services
{
    public interface IFilesService
    {
        Task<byte[]> GetFile(string filesName);
        Task<string> ReadJsonFile(string nameFile);
        Task<string> UploadFile(IFormFile file);
    }
}