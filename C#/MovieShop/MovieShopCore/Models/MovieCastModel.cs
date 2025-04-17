namespace MovieShopCore.Models;

public class MovieCastModel
{
    public int CastId { get; set; }
    public CastModel CastModel { get; set; }
    
    public string? Character { get; set; }
    
    public int MovieId { get; set; }
    public MovieCardModel MovieCardModel { get; set; }
}