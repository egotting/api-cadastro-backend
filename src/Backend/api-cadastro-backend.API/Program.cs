
using api_cadastro_backend.Infrastructure.Data.Configuration;
using api_cadastro_backend.Infrastructure.Extensions;
using api_cadastro_backend.loC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.ConfigureService(builder.Configuration);

var app = builder.Build();
await app.Services.RunMigrations();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.MapControllers();
//app.UseHttpsRedirection();
app.Run();
