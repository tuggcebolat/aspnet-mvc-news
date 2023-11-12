using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities.Models;

namespace News.DAL.EntityMappings
{
    public class NewsImageMapping : IEntityTypeConfiguration<NewsImage>
    {
        public void Configure(EntityTypeBuilder<NewsImage> builder)
        {
            builder.Property(c => c.ImagePath).HasMaxLength(200);

            builder.HasOne(ni => ni.News)
                .WithMany(n => n.NewsImages)
                .HasForeignKey(ni => ni.NewsId);
        }
    }
}
