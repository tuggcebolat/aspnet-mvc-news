namespace News.Entities.Models
{
    public class NewsImage : BaseEntity
    {
        public int NewsId { get; set; }
        public string ImagePath { get; set; }

        public News News { get; set; }
    }
}
