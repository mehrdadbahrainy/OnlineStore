using System.Data.Entity;
using OnlineStore.Entities.Entities;

namespace OnlineStore.DataAccess
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext()
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .ToTable("Category");

            modelBuilder.Entity<Item>()
                .ToTable("Item");

            modelBuilder.Entity<Order>()
                .ToTable("Order");

            modelBuilder.Entity<OrderItem>()
                .ToTable("OrderItem");

            modelBuilder.Entity<User>()
                .ToTable("User");

        }
    }

}
