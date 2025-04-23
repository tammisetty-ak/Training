using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Order_Detail
{
    public int Id { get; set; }
    [Required]
    public int Product_Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(40)")]
    public string Product_name { get; set; } = string.Empty;
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    
    public int OrderId { get; set; }
    
    //nav prop
    public Order Order { get; set; } = new Order();
}