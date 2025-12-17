using CoreWCF;
using BillingService.Models;

namespace BillingService.Services
{
    [ServiceContract(
        Namespace = "http://tempuri.org/"
    )]
    public interface IBillingService
    {
        [OperationContract]
        string Ping();

        [OperationContract]
        CreateInvoiceResponse CreateInvoice(CreateInvoiceRequest request);

        [OperationContract]
        GetInvoiceResponse GetInvoice(GetInvoiceRequest request);

        [OperationContract]
        GetAllInvoicesResponse GetAllInvoices();
    }
}
