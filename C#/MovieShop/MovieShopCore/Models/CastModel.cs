namespace MovieShopCore.Models;

public class CastModel
{
    public int Id { get; set; }
    
    public string? Gender { get; set; }
    
    public string? Name { get; set; }
    
    public string? ProfilePath { get; set; }
    
    public string? TmdbUrl { get; set; }
    
    public ICollection<MovieCastModel> MoviesCastModels { get; set; }
}