using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderApi.Models;

namespace OrderApi.DAL.EntitiesConfigurations
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Number);
            builder.Property(o => o.Status).HasConversion<int>().IsRequired();
            builder.Property(o => o.Products).IsRequired();
            builder.Property(o => o.Price).IsRequired();
            builder.Property(o => o.PostTerminalNumber).IsRequired();
            builder.Property(o => o.PhoneNumber).IsRequired();
            builder.Property(o => o.RecipientFullName).IsRequired();
        }
    }
}