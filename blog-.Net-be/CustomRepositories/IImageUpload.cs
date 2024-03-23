using blog_.Net_be.Models;

namespace blog_.Net_be.CustomRepositories
{
    public interface IImageUpload
    {
        public Task<Image> Upload(Image image);
    }
}
