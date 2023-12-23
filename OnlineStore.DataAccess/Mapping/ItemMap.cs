using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Entities.Entities;

namespace OnlineStore.DataAccess.Mapping
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item", "dbo");

            builder.HasOne<Category>(x => x.MainCategory)
                .WithMany(x => x.MainItems)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();

            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Items)
                .UsingEntity<ItemCategory>();
        }
    }
}
