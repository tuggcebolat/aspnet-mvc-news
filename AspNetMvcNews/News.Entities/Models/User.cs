namespace News.Entities.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? City { get; set; }

        public ICollection<Setting> Settings { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<NewsComment> NewsComments { get; set; }
    }
}
