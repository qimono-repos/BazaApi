using MongoDB.Entities;
using BazaApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();
Console.WriteLine("Created builder with controller and graphql");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL("/graphql");

Console.WriteLine("Configure the HTTP request pipeline");

await DB.InitAsync("BazaDb", "mongodb://localhost:27017");
await SeedDataAsync();

app.Run();

async Task SeedDataAsync()
{
  Console.WriteLine("SeedDataAsync");

    if (await DB.CountAsync<ImageModel>() == 0)
    {
        await new ImageModel { Name = "Image 1", Url = "http://example.com/img1.jpg" }.SaveAsync();
        await new ImageModel { Name = "Image 2", Url = "http://example.com/img2.jpg" }.SaveAsync();
    }
}
