namespace blog_.Net_be.dto
{
    public class ImageDto
    {
        public IFormFile FormFile { get; set; }
        public string? FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
