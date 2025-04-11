using System;
using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados (Exemplo: Entity Framework com SQL Server)
builder.Services.AddDbContext<EcommerceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro dos repositories como serviços injetáveis
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();

// Adiciona controllers
builder.Services.AddControllers();

// Build da aplicação
var app = builder.Build();
// Adicionar suporte ao Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Habilitar o Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API E-Commerce v1");
        c.RoutePrefix = string.Empty; // Para acessar diretamente em /
    });
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapControllers();

app.Run();


app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();