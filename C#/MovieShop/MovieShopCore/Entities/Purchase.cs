using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopCore.Entities;

public class Purchase
{
    [ForeignKey(nameof(Movie))]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }
    
    public DateTime PurchaseDateTime { get; set; }
    public Guid PurchaseId { get; set; }
    public decimal TotalPrice { get; set; }
}