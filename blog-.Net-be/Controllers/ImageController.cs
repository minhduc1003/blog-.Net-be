using blog_.Net_be.CustomRepositories;
using blog_.Net_be.dto;
using blog_.Net_be.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog_.Net_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageUpload imageUpload;

        public ImageController(IImageUpload imageUpload)
        {
            this.imageUpload = imageUpload;
        }
        [Route("Upload")]
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] ImageDto imageDto)
        {
            check(imageDto);
            if (ModelState.IsValid)
            {
                var image = new Image
                {
                    FileDescription = imageDto.FileDescription,
                    FormFile = imageDto.FormFile,
                    FileExtention = Path.GetExtension(imageDto.FormFile.FileName),
                    FileName = imageDto.FormFile.FileName,
                    FileSizeInByte = imageDto.FormFile.Length
                };
               var rs = await imageUpload.Upload(image);
                return Ok(rs);
            }

            return BadRequest(ModelState);

        }
        private void check(ImageDto image)
        {
            var allowFileExtentions = new string[] {".jpg",".jpeg",".png" };
            if (!allowFileExtentions.Contains(Path.GetExtension(image.FormFile.FileName)) == true)
            {
                ModelState.AddModelError("file", "unsupport file");
            }
            if (image.FormFile.Length > 10485760)
            {
                ModelState.AddModelError("file", "upload image lowwer 10 mb");
            }
        }
    }
}

