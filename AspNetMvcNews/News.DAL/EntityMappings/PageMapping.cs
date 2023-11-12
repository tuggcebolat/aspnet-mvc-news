using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace News.DAL.EntityMappings
{
    public class PageMapping : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(200);
            builder.Property(c => c.Title).HasColumnType<string>(SqlDbType.Text.ToString());
        }
    }
}
