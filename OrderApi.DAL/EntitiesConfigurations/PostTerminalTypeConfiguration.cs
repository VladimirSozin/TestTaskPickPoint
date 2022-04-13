using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderApi.Models;

namespace OrderApi.DAL.EntitiesConfigurations
{
    public class PostTerminalTypeConfiguration : IEntityTypeConfiguration<PostTerminal>
    {
        public void Configure(EntityTypeBuilder<PostTerminal> builder)
        {
            builder.HasKey(t => t.Number);
            builder.Property(t => t.Address).HasMaxLength(100);
            builder.Property(t => t.IsActive);
        }
    }
}
