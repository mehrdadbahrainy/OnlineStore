using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Entities.Entities;

namespace OnlineStore.DataAccess.Mapping;

public class ItemCategoryMap : IEntityTypeConfiguration<ItemCategory>
{
    public void Configure(EntityTypeBuilder<ItemCategory> builder)
    {
        builder.ToTable("ItemCategory", "dbo");


        builder.Navigation(x => x.Item);
        builder.Navigation(x => x.Category);
        
        builder.HasOne<Item>(x => x.Item)
            .WithMany()
            .HasForeignKey(x => x.ItemId);

        builder.HasOne<Category>(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId);
    }
}