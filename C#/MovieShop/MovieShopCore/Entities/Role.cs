using System.ComponentModel.DataAnnotations;

namespace MovieShopCore.Entities;

public class Role
{
    public int Id { get; set; }
    
    [MaxLength(20)]
    public string? Name { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; }
}