using OnlineStore.DataAccess;
using OnlineStore.Entities.Entities;

namespace OnlineStore.Service;

public class RoleService : BaseService<Role>
{
    public RoleService(StoreDataContext dataContext) : base(dataContext)
    {
    }
}