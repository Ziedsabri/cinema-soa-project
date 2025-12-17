using System.Runtime.Serialization;

namespace BillingService.Models
{
    [DataContract(
        Namespace = "http://schemas.datacontract.org/2004/07/BillingService.Models"
    )]
    public class GetInvoiceResponse
    {
        [DataMember(Order = 1)]
        public Invoice Invoice { get; set; }
    }
}
