namespace OnlineStore.Service;

public class StoreServices
{
    public CategoryService CategoryService { get; }
    public ItemService ItemService { get; }
    public OrderService OrderService { get; }
    public UserService UserService { get; }

    public StoreServices(
        CategoryService categoryService,
        ItemService itemService,
        OrderService orderService,
        UserService userService)
    {
        CategoryService = categoryService;
        ItemService = itemService;
        OrderService = orderService;
        UserService = userService;
    }
}