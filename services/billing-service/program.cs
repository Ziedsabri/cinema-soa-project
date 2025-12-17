using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using BillingService.Services;
using BillingService.Implementation;
using Microsoft.AspNetCore.HttpOverrides; // Required for Forwarded Headers

var builder = WebApplication.CreateBuilder(args);

// 1. Add Services
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();

// 2. CRITICAL: Register the behavior that fixes WSDL URLs for Docker/Gateways
// This tells CoreWCF to use the 'Host' header from the gateway for the WSDL addresses
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

builder.Services.AddSingleton<IBillingService, BillingServiceImpl>();

var app = builder.Build();

// 3. IMPORTANT: Tell ASP.NET to trust the Gateway's forwarded headers
// This ensures the app knows it is being accessed via port 5102
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedHost
});

app.MapGet("/", () => "BillingService is running");

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<BillingServiceImpl>(options =>
    {
        options.DebugBehavior.IncludeExceptionDetailInFaults = true;
    });

    serviceBuilder.AddServiceEndpoint<BillingServiceImpl, IBillingService>(
        new BasicHttpBinding(),
        "/BillingService/soap"
    );

    // 4. Simplified Metadata Configuration
    var metadata = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    metadata.HttpGetEnabled = true;
    
    // We don't need to manually add it to the host here because 
    // AddServiceModelMetadata() already puts it in DI for us.
});

app.Run();