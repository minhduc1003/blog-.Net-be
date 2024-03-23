using blog_.Net_be.data;
using blog_.Net_be.Models;

namespace blog_.Net_be.CustomRepositories
{
    public class ImageUploadRepository : IImageUpload
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BlogDbContext dbContext;

        public ImageUploadRepository(IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor,BlogDbContext _dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            dbContext = _dbContext;
        }
        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}");
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.FormFile.CopyToAsync(stream);
            var ulrFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}";
            image.FilePath = ulrFilePath;
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();
            return image;
            
        }
    }
}
