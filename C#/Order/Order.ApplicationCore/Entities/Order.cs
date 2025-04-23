using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Order
{
    public int Id { get; set; }
    [Required]
    public DateTime Order_Date { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string CustomerName { get; set; } = string.Empty;
    [Required]
    public int PaymentMethodId { get; set; }
    [Required]
    [Column(TypeName = "varchar(30)")]
    public string PaymentMethodName { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string ShippingMethodAddress { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string ShippingMethod { get; set; } = string.Empty;
    [Required]
    public decimal BillAmount { get; set; }
    [Required]
    public string Order_Status { get; set; } = string.Empty;
    
    public ICollection<Order_Detail> Order_Details { get; set; } = new List<Order_Detail>();
}