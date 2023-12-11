using OnlineStore.DataAccess;
using OnlineStore.Entities.Entities;

namespace OnlineStore.Service;

public class OrderService : BaseService<Order>
{
    public OrderService(StoreDataContext dataContext) : base(dataContext)
    {
    }
}