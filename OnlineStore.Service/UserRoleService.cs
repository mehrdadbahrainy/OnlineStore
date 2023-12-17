using OnlineStore.DataAccess;
using OnlineStore.Entities.Entities;

namespace OnlineStore.Service;

public class UserRoleService : BaseService<UserRole>
{
    public UserRoleService(StoreDataContext dataContext) : base(dataContext)
    {
    }
}