namespace MovieShopCore.Models;

public class MovieDetailsModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Runtime { get; set; }
    public decimal Budget { get; set; }
    public decimal Revenue { get; set; }
    public string? PosterURL { get; set; }
    public string Overview { get; set; }
    public string TagLine { get; set; }
    public string TmdbUrl { get; set; }
    
    public IEnumerable<MovieCastModel> MovieCastModels { get; set; }
}