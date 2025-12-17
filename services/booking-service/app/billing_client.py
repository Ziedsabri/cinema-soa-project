import requests

# CONSTANT GATEWAY URL - Never change this
BILLING_URL = "http://billing-service:8080/BillingService/soap"
SOAP_ACTION = '"http://tempuri.org/IBillingService/CreateInvoice"'

def create_invoice(invoice_id, customer_name, amount):
    # 'mod' namespace ensures 'request.InvoiceId' is not null in C#
    xml = f"""<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"
               xmlns:tem="http://tempuri.org/"
               xmlns:mod="http://schemas.datacontract.org/2004/07/BillingService.Models">
  <soap:Body>
    <tem:CreateInvoice>
      <tem:request>
        <mod:InvoiceId>{invoice_id}</mod:InvoiceId>
        <mod:CustomerName>{customer_name}</mod:CustomerName>
        <mod:Amount>{amount}</mod:Amount>
      </tem:request>
    </tem:CreateInvoice>
  </soap:Body>
</soap:Envelope>"""

    headers = {
        "Content-Type": "text/xml; charset=utf-8",
        "SOAPAction": SOAP_ACTION
    }

    try:
        response = requests.post(BILLING_URL, data=xml, headers=headers)
        return response.text
    except Exception as e:
        return f"Gateway Connection Error: {e}"

if __name__ == "__main__":
    # Test the permanent setup
    print(create_invoice("INV-SUCCESS-1", "Aziz", 100.00))