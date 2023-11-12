namespace News.Entities.Models
{
    public class Setting : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public User User { get; set; }
    }
}
