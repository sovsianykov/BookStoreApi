using Microsoft.AspNetCore.Mvc;
using MyWebApi.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBookStorage, BookStorage>();
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<ApplicationAssemblyMarker>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

