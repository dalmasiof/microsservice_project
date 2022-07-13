using UserService;
using UserService.Requisitions;
using UserService.Service;
using UserService.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, User_Service>();

builder.Services.AddScoped<IUserRequest, Reqs>();

builder.Services.AddAutoMapper(typeof(AutoMapping).Assembly);



//builder.Services.AddScoped<IBaseHttpClient<UserData>, HttpRequisition<UserData>>();

//builder.Services.AddSingleton<IMessageSender, MessageSender>();

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
