using System.ComponentModel.DataAnnotations.Schema;

namespace blog_.Net_be.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtention { get; set;}
        public long FileSizeInByte { get; set; }
        public string FilePath { get; set; }
    }
}
