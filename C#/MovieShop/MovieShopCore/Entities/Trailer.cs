using System.ComponentModel.DataAnnotations;

namespace MovieShopCore.Entities;

public class Trailer
{
    public int Id { get; set; }
    [MaxLength(256)]
    public string? TrailerUrl { get; set; }
    [MaxLength(256)]
    public string? Name { get; set; }
    
    public int MovieId { get; set; } 
    public Movie Movie { get; set; }
}