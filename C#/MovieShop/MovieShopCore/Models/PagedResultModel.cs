
namespace MovieShopApp.Models;

public class PagedResultModel <T>
{
    public List<T> Items { get; set; }
    public int      CurrentPage{ get; set; }
    public int      PageSize   { get; set; }
    public int      TotalItems { get; set; }
    public int      TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    public bool     HasPrevious => CurrentPage > 1;
    public bool     HasNext     => CurrentPage < TotalPages;
}