using OnlineStore.DataAccess;
using OnlineStore.Entities.Entities;

namespace OnlineStore.Service;
public class UserService : BaseService<User>
{
    public UserService(StoreDataContext dataContext) : base(dataContext)
    {
    }
}
