using blog_.Net_be.data;
using blog_.Net_be.Models;
using blog_.Net_be.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogDbContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnectString")));
builder.Services.AddScoped<IRepositories<Blog>, Repositories<Blog>>();
builder.Services.AddScoped<IRepositories<Category>, Repositories<Category>>();
builder.Services.AddScoped<UnitOfWork>();

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
