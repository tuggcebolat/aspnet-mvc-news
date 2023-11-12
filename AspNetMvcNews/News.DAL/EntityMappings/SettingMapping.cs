using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities.Models;

namespace News.DAL.EntityMappings
{
    public class SettingMapping : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(200);
            builder.Property(s => s.Value).HasMaxLength(400);

            builder.HasOne(s => s.User)
                .WithMany(u => u.Settings)
                .HasForeignKey(s => s.UserId);
        }
    }
}
