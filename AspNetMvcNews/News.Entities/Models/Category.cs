﻿namespace News.Entities.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<News> News { get; set; }
    }
}
