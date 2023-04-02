using CustomCollectionService;
using Microsoft.EntityFrameworkCore;
using TimerService;
using WebQueue.Data;
using WebQueue.Models;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<QueueCollection<Message>>();
builder.Services.AddSingleton<SaveProcessTrigger>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
