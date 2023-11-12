using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Contexts
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News.Entities.Models.News> News { get; set; }
        public DbSet<NewsComment> NewsComments { get; set; }
        public DbSet<NewsImage> NewsImages { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
