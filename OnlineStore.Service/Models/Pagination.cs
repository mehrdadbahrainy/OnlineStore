using System.Data.SqlClient;

namespace OnlineStore.Service.Models
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public SortOrder SortOrder { get; set; }
        public string? OrderBy { get; set; }
    }
}
