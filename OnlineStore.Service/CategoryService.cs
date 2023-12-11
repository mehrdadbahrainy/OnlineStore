using OnlineStore.DataAccess;
using OnlineStore.Entities.Entities;

namespace OnlineStore.Service;

public class CategoryService : BaseService<Category>
{
    public CategoryService(StoreDataContext dataContext) : base(dataContext)
    {
    }
}