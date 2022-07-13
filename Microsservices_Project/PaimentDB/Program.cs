using Microsoft.EntityFrameworkCore;
using PaymentDB.Consumer;
using PaymentDB.Data.Context;
using PaymentDB.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<PaymentConsumer>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();


var conStrgn = builder.Configuration.GetConnectionString("ConString");
builder.Services.AddDbContext<PaymentCOntext>(options => options.UseMySql(conStrgn, ServerVersion.AutoDetect(conStrgn)));

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
