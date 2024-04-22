using AvaliacaoQuestor.Api.Configurations;
using AvaliacaoQuestor.Business.Features;
using AvaliacaoQuestor.Domain.Features;
using AvaliacaoQuestor.Domain.Shared;
using AvaliacaoQuestor.Infra;
using AvaliacaoQuestor.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Postgresql");

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddDbContext<AvaliacaoQuestorDBContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<AvaliacaoQuestorDBContext>();

builder.Services.AddScoped<BancosBLL>();
builder.Services.AddScoped<BoletosBLL>();
builder.Services.AddScoped<IRepository<Bancos>, BancoRepository>();
builder.Services.AddScoped<IRepository<Boletos>, BoletoRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
