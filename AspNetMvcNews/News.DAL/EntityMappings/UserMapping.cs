using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities.Models;

namespace News.DAL.EntityMappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.Email).HasMaxLength(200).IsRequired(false);
            builder.Property(c => c.Password).HasMaxLength(100);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.City).HasMaxLength(100);
        }
    }
}
