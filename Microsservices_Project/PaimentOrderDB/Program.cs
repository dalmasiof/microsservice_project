using Microsoft.EntityFrameworkCore;
using PaymentOrderDB.Consumer;
using PaymentOrderDB.Data.Context;
using PaymentOrderDB.Data.Repository;
using PaymentOrderDB.Data.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<PaymentOrderConsumer>();
builder.Services.AddScoped<IPORepository, PORepository>();

var conStrgn = builder.Configuration.GetConnectionString("ConString");

builder.Services.AddDbContext<PaymentOrderContext>(options => options.UseMySql(conStrgn, ServerVersion.AutoDetect(conStrgn)));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
