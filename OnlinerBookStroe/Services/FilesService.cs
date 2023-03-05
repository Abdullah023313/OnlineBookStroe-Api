using OnlineBookStroe.Data;


namespace OnlineBookStroe.Services
{
    public class FilesService : IFilesService
    {
        public async Task<string> UploadFiles(IFormFile file)
        {
            string fakeFileName = Path.GetRandomFileName();
            var path = Path.Combine(Environment.CurrentDirectory, "Uploads", fakeFileName);
            using FileStream fileStream = new(path, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return fakeFileName;
        }
        public Task<byte[]> GetFiles(string imageName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "Uploads", imageName);
            return File.ReadAllBytesAsync(filePath);
        }
    }
}
