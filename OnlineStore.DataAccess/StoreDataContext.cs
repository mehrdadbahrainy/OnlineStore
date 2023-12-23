using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.Mapping;
using OnlineStore.Entities.Entities;

namespace OnlineStore.DataAccess
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext(DbContextOptions<StoreDataContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemCategory> ItemCategory { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ItemMap());
            modelBuilder.ApplyConfiguration(new ItemCategoryMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());

        }
    }

}
