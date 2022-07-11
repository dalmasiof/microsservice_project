using PaymentService;
using PaymentService.Requisition.Interface;
using PaymentService.Service.Interfaces;
using PaymentService.Service;
using PaymentService.Requisition;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingConfig).Assembly);
builder.Services.AddScoped<IRequisitionPayment, RequisitionPayment>();
builder.Services.AddScoped<IPaymentService, PaymentServices>();

var app = builder.Build();



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
