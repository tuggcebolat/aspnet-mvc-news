namespace News.Entities.Models
{
    public class News : BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public User User { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<NewsImage> NewsImages { get; set; }
        public ICollection<NewsComment> NewsComments { get; set; }
    }
}
