using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Order
{
    public string Id { get; set; }
    
    public DateTime Order_Date { get; set; }
    
    public int CustomerId { get; set; }
    
    public string CustomerName { get; set; }
    
    public string PaymentMethodId { get; set; }
    
    public string PaymentMethodName { get; set; }
    
    public string ShippingMethodAddress { get; set; }
    
    public string ShippingMethod { get; set; }
    
    public decimal BillAmount { get; set; }
    
    public Enum Order_Status { get; set; }
}