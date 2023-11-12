﻿namespace News.Entities.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
    }
}
