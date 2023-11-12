using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace News.DAL.EntityMappings
{
    public class NewsMapping :IEntityTypeConfiguration<News.Entities.Models.News>
    {
        public void Configure(EntityTypeBuilder<News.Entities.Models.News> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(200);
            builder.Property(c => c.Content).HasColumnType(SqlDbType.NText.ToString());

            builder.HasOne(n => n.User)
                .WithMany(u => u.News)
                .HasForeignKey(n => n.UserId);
        }
    }
}
