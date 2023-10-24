namespace blog_.Net_be.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public Category category { get; set; }

    }
}
