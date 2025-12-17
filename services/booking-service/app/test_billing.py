from billing_client import create_invoice

response = create_invoice("INV-123", "Alice", 42.50)
print(response)
