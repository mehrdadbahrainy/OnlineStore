using OnlineStore.DataAccess;
using OnlineStore.Entities.Entities;

namespace OnlineStore.Service;

public class ItemCategoryService : BaseService<ItemCategory>
{
    public ItemCategoryService(StoreDataContext dataContext) : base(dataContext)
    {
    }
}