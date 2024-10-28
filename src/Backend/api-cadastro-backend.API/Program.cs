
using api_cadastro_backend.Infrastructure.Data.Configuration;
using api_cadastro_backend.Infrastructure.Extensions;
using api_cadastro_backend.loC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.ConfigureService(builder.Configuration);
builder.Services.ConfigureUseCasesHandlers();
builder.Services.ConfigureUseCaseHandlersResponse();
builder.Services.ConfigurationUseCaseHandlersRequest();
builder.Services.ConfigureValidators();

var app = builder.Build();
await app.Services.RunMigrations();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();    
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
