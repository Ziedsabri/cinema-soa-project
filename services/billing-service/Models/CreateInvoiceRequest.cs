using System.Runtime.Serialization;

namespace BillingService.Models
{
    [DataContract(
        Namespace = "http://schemas.datacontract.org/2004/07/BillingService.Models"
    )]
    public class CreateInvoiceRequest
    {
        [DataMember(Order = 1)]
        public string InvoiceId { get; set; }

        [DataMember(Order = 2)]
        public string CustomerName { get; set; }

        [DataMember(Order = 3)]
        public decimal Amount { get; set; }
    }
}
