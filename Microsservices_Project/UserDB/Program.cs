using Microsoft.EntityFrameworkCore;
using UserDB.Data.Context;
using UserDB.Data.Repository;
using UserDB.MessageConsumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conStrgn = builder.Configuration.GetConnectionString("ConString");

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(conStrgn));

var teste = new DbContextOptionsBuilder<UserContext>();
teste.UseSqlServer(conStrgn);


builder.Services.AddSingleton(new UserRepository(teste.Options));

builder.Services.AddHostedService<ConsumerMessage>();




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
