using System.Runtime.Serialization;

namespace BillingService.Models
{
    [DataContract(
        Namespace = "http://schemas.datacontract.org/2004/07/BillingService.Models"
    )]
    public class Invoice
    {
        [DataMember(Order = 1)]
        public string InvoiceId { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public string CustomerName { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public decimal Amount { get; set; }
    }
}
