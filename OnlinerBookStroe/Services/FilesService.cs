using OnlineBookStroe.Data;

namespace OnlineBookStroe.Services
{
    public class FilesService : IFilesService
    {
        public string PathRoot(string nameFile)
        {
            return Path.Combine(Environment.CurrentDirectory, "wwwroot", nameFile);
        }

        public async Task<string> ReadJsonFile(string nameFile)
        {
            string path = PathRoot("FakeData/"+nameFile);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            return await File.ReadAllTextAsync(path);
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string fakeFileName = Path.GetRandomFileName();
            var path = PathRoot(fakeFileName);
            using FileStream fileStream = new(path, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return fakeFileName;
        }

        public Task<byte[]> GetFile(string filesName)
        {
            string filePath = PathRoot(filesName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            return File.ReadAllBytesAsync(filePath);
        }
    }
}
