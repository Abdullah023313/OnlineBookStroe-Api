
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStroe.Services;

namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFilesService _filesService;

        public FileController(IFilesService filesService)
        {
            _filesService = filesService;
        }


        [HttpPost("UploadFile")]
        public async Task<ActionResult<string>> UploadFile(IFormFile file)
        {
            string nameFile = await _filesService.UploadFile(file);
            return Ok(nameFile);
        }

        [HttpGet("GetImage")]
        public async Task<ActionResult> GetImage(string imageName)
        {
            return File(await _filesService.GetFile(imageName), "image/jpeg");
        }

        [HttpGet("GetPdf")]
        public async Task<ActionResult> GetPdf(string PdfName)
        {
            return File(await _filesService.GetFile(PdfName),"Application/pdf");
        }
    }
}
