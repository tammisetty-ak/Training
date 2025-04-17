using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MovieShopCore.Entities;

public class Review
{
    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public decimal Rating { get; set; }
    
    [MaxLength(1024)]
    public string ReviewText { get; set; }
}