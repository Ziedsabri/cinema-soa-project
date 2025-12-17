using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BillingService.Models
{
    [DataContract(
        Namespace = "http://schemas.datacontract.org/2004/07/BillingService.Models"
    )]
    public class GetAllInvoicesResponse
    {
        [DataMember(Order = 1)]
        public List<Invoice> Invoices { get; set; } = new();
    }
}
