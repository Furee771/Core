using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
});

var app = builder.Build();
 
app.MapControllers();



var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SteedData.SteedDatabase(context);

app.MapGet("/", () => "Hello Wrold!");

app.Run();
