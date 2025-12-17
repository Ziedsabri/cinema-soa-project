namespace BillingService.Models;

public class PaymentDetails
{
    public string Method { get; set; } // e.g., "CreditCard", "Cash"
    public decimal AmountPaid { get; set; }
    public DateTime PaidAt { get; set; }
}
