using System.ComponentModel.DataAnnotations;

namespace MovieShopCore.Entities;

public class Genre
{
    public int Id { get; set; }
    
    [MaxLength(64)]
    public string Name { get; set; }
    
    public ICollection<MovieGenre> Movies { get; set; }
}