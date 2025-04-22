using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Order_Details
{
    public int Id { get; set; }
    
    public int Order_Id { get; set; }
    
    public int Product_Id { get; set; }
    
    public string Product_name { get; set; }
    
    public decimal Quantity { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal Discount { get; set; }
}