using API_BancAtlan_EstadoCuenta.Entities;
using API_BancAtlan_EstadoCuenta.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BancAtlanEstadoCuentaContext>(options => options.UseSqlServer("Name=ConnectionStrings:BancAtlan"));
builder.Services.AddScoped<IFacadeRepository<Cliente>, ClienteRepository>();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    BancAtlanEstadoCuentaContext context = scope.ServiceProvider.GetRequiredService<BancAtlanEstadoCuentaContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
