namespace News.Entities.Models
{
    public class NewsComment : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }

        public News News { get; set; }
        public User User { get; set; }
    }
}
