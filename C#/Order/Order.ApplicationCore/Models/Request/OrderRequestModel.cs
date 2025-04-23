using System.ComponentModel.DataAnnotations;

namespace API.Models.Request;

public class OrderRequestModel
{
    
    [Required(ErrorMessage = "CustomerID is required")]
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "PaymentID is required")]
    public int PaymentMethodId { get; set; }
    
    public string PaymentMethodName { get; set; } = string.Empty;
   
    public string ShippingMethodAddress { get; set; } = string.Empty;
    
    public string ShippingMethod { get; set; } = string.Empty;
    
    public decimal BillAmount { get; set; } = decimal.Zero;
    
    public string Order_Status { get; set; } = string.Empty;
    
    public DateTime Order_Date { get; set; } =  DateTime.UtcNow;


}