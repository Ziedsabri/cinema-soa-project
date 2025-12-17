using System.Runtime.Serialization;

namespace BillingService.Models;

[DataContract(Namespace = "http://schemas.datacontract.org/2004/07/BillingService.Models")]
public class InvoiceItem
{
    [DataMember]
    public string Description { get; set; }

    [DataMember]
    public int Quantity { get; set; }

    [DataMember]
    public decimal UnitPrice { get; set; }

    [DataMember]
    public decimal LineTotal { get; set; }
}
