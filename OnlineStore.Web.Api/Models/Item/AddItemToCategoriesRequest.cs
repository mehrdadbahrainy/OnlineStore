namespace OnlineStore.Web.Api.Models.Item;

public class AddItemToCategoriesRequest : ApiRequest
{
    public int ItemId { get; set;}
    public List<int> CategoryIds { get; set; }
}