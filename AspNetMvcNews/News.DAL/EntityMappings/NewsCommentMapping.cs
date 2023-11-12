using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities.Models;
using System.Data;

namespace News.DAL.EntityMappings
{
    public class NewsCommentMapping : IEntityTypeConfiguration<NewsComment>
    {
        public void Configure(EntityTypeBuilder<NewsComment> builder)
        {
            builder.Property(c => c.Comment).HasColumnType(SqlDbType.Text.ToString());

            builder.HasOne(nc => nc.User)
                .WithMany(u => u.NewsComments)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(nc => nc.UserId);

            builder.HasOne(nc => nc.News)
                .WithMany(n => n.NewsComments)
                .HasForeignKey(nc => nc.PostId);
        }
    }
}
