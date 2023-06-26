using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using MyWebApi.Application;
using MyWebApi.Application.DTO;
using MyWebApi.Application.Features;
using MyWebApi.Infra;
using MyWebApi.Infra.Models;
using MyWebApi.WebApp.Filters;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();


builder.Services.AddDbContext<BooksContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("MyConnection"),
        b => b.MigrationsAssembly("MyWebApi.WebApp")));






var mapperConfig = new MapperConfiguration(config =>
{
    config.CreateMap<CreateBookRequest, Book>();
    config.CreateMap<Book, Dto>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<ApplicationAssemblyMarker>());
builder.Services.Configure<MvcOptions>(cfg => cfg.Filters.Add<ExceptionHandlingFilter>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyWebApi", Version = "v1" });
});
var app = builder.Build();




app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApi v1");
    c.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

