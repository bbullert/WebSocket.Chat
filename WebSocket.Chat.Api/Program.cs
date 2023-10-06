using Chat.Api.Extnesions;
using Chat.Core.Hubs;
using WebSocketLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices();
builder.Services.RegisterRepositries();
builder.Services.RegisterValidators();
builder.Services.AddWebSocketDependencies();

//builder.Services.AddTransient<ChatHub>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder => builder
        .WithOrigins("http://localhost:5000", "https://localhost:5001")
        .WithOrigins("http://localhost:8080", "https://localhost:8080")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
}

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};
app.UseWebSockets(webSocketOptions);

app.MapWebSocketHub<ChatHub>("/chat");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
