using Microsoft.EntityFrameworkCore;
using todoApi.Data;
using todoApi.Repositories;
using todoApi.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));


builder.Services.AddScoped<TodoRepositoryInterface, TodoRepository>();
builder.Services.AddScoped<TodoServiceInterface, TodoService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();