namespace OnlineStore.Entities.Entities;

public class OrderItem : IBaseEntity
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime EntryDate { get; set; }
    public bool IsDeleted { get; set; }
}