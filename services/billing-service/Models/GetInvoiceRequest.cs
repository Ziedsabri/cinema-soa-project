using System.Runtime.Serialization;

namespace BillingService.Models
{
    [DataContract(
        Namespace = "http://schemas.datacontract.org/2004/07/BillingService.Models"
    )]
    public class GetInvoiceRequest
    {
        [DataMember(Order = 1)]
        public string InvoiceId { get; set; }
    }
}
