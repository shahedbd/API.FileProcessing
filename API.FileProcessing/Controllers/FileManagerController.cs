using API.FileProcessing.Service;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadDownload.Controllers
{
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        private readonly IManageImage _iManageImage;
        public FileManagerController(IManageImage iManageImage)
        {
            _iManageImage = iManageImage;
        }

        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> UploadFile(IFormFile _IFormFile)
        {
            var result = await _iManageImage.UploadFile(_IFormFile);
            return Ok(result);
        }

        [HttpGet]
        [Route("downloadfile")]
        public async Task<IActionResult> DownloadFile(string FileName)
        {
            var result = await _iManageImage.DownloadFile(FileName);
            return File(result.Item1, result.Item2, result.Item2);
        }
    }
}
