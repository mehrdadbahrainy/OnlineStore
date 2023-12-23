using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Api.Models.Item;

public class GetItemCategoriesRequest : ApiRequest
{
    [FromRoute(Name = "itemId")]
    public int? ItemId { get; set; }
}