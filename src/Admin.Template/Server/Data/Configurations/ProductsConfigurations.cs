
using Admin.Template.Server.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(b => b.Name)
            .IsRequired();

        builder
            .Property(b => b.Price)
            .IsRequired();

        
    }
}