    using System.Collections.Generic;
    using BillingService.Models;
    using BillingService.Services;

    namespace BillingService.Implementation
    {
        public class BillingServiceImpl : IBillingService
        {
            // In-memory invoice store
            private static readonly Dictionary<string, Invoice> _invoices =
                new Dictionary<string, Invoice>();

            public string Ping()
            {
                return "Billing service is alive";
            }

            public CreateInvoiceResponse CreateInvoice(CreateInvoiceRequest request)
{
    Console.WriteLine("Received CreateInvoice request");
    Console.WriteLine("Success = true");
    // Check if the request or the key is null to prevent ArgumentNullException
    if (request == null || string.IsNullOrEmpty(request.InvoiceId))
    {
        // This sends a clear error back to Python instead of crashing
        throw new CoreWCF.FaultException("Invalid Request: InvoiceId cannot be null. Check your XML namespaces.");
    }

    var invoice = new Invoice
    {
        InvoiceId = request.InvoiceId,
        CustomerName = request.CustomerName,
        Amount = request.Amount
    };

    _invoices[invoice.InvoiceId] = invoice;

    return new CreateInvoiceResponse { Success = true };
}

            public GetInvoiceResponse GetInvoice(GetInvoiceRequest request)
            {
                _invoices.TryGetValue(request.InvoiceId, out var invoice);

                return new GetInvoiceResponse
                {
                    Invoice = invoice
                };
            }

            public GetAllInvoicesResponse GetAllInvoices()
            {
                return new GetAllInvoicesResponse
                {
                    Invoices = new List<Invoice>(_invoices.Values)
                };
            }
        }
    }
