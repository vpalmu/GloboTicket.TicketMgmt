using GloboTicket.TicketManagement.API;
using GloboTicket.TicketManagement.Persistance;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureServices()
                 .ConfigureMiddleware();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbInitializer = services.GetRequiredService<DbInitialiser>();

    dbInitializer.Run();
}

app.Run();


// This partial class declaration is needed so that CustomWebApplicationFactory from Api.IntegationTest project can initiate the API.
// If removed will cause:
//  System.InvalidOperationException : 'Can't find 'C:\Users\vesa.palmu\repos\GloboTicket.TicketMgmt\GloboTicket.TicketManagement.API.IntegrationTests\bin\Debug\net6.0\testhost.deps.json'.
public partial class Program { }