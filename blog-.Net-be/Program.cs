using blog_.Net_be.CustomRepositories;
using blog_.Net_be.data;
using blog_.Net_be.dto;
using blog_.Net_be.mapper;
using blog_.Net_be.Models;
using blog_.Net_be.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogDbContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnectString")));
builder.Services.AddScoped<IRepositories<Blog>, Repositories<Blog>>();
builder.Services.AddScoped<IRepositories<Category>, Repositories<Category>>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyHeader()
                                                  .AllowAnyMethod(); ;
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
