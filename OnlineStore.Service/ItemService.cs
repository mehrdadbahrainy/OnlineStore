using OnlineStore.DataAccess;
using OnlineStore.Entities.Entities;

namespace OnlineStore.Service;

public class ItemService : BaseService<Item>
{
    public ItemService(StoreDataContext dataContext) : base(dataContext)
    {
    }
}