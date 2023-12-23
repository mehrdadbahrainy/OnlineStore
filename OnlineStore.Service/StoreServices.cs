namespace OnlineStore.Service;

public class StoreServices
{
    public CategoryService CategoryService { get; }
    public ItemService ItemService { get; }
    public ItemCategoryService ItemCategoryService { get; }
    public OrderService OrderService { get; }
    public RoleService RoleService { get; }
    public UserService UserService { get; }
    public UserRoleService UserRoleService { get; }

    public StoreServices(
        CategoryService categoryService,
        ItemService itemService,
        ItemCategoryService itemCategoryService,
        OrderService orderService,
        RoleService roleService,
        UserService userService,
        UserRoleService userRoleService)
    {
        CategoryService = categoryService;
        ItemService = itemService;
        ItemCategoryService = itemCategoryService;
        OrderService = orderService;
        RoleService = roleService;
        UserService = userService;
        UserRoleService = userRoleService;
    }
}