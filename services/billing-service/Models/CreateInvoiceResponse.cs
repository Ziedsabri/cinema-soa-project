using System.Runtime.Serialization;

namespace BillingService.Models
{
    [DataContract(
        Namespace = "http://schemas.datacontract.org/2004/07/BillingService.Models"
    )]
    public class CreateInvoiceResponse
    {
        [DataMember(Order = 1)]
        public bool Success { get; set; }
    }
}
