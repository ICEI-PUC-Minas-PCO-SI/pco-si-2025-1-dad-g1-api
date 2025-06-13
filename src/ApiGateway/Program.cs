using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Carrega a configuração do Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Adiciona os serviços do Ocelot
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Adiciona o middleware do Ocelot ao pipeline
await app.UseOcelot();

app.Run();