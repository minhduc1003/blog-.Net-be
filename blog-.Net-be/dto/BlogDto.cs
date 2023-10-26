using blog_.Net_be.Models;

namespace blog_.Net_be.dto
{
    public class BlogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public Guid CategoryId { get; set; }
    }
}
