using System.ComponentModel.DataAnnotations;

namespace MovieShopCore.Entities;

public class Cast
{
    public int Id { get; set; }
    
    [MaxLength(8)]
    public string? Gender { get; set; }
    
    [MaxLength(128)]
    public string? Name { get; set; }
    
    [MaxLength(2084)]
    public string? ProfilePath { get; set; }
    
    [MaxLength(2084)]
    public string? TmdbUrl { get; set; }
    
    public ICollection<MovieCast> Movies { get; set; }
}