using MongoDB.Entities;
using ImageApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

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
app.MapGraphQL("/graphql");

await DB.InitAsync("ImageDb", "mongodb://localhost:27017");
await SeedDataAsync();

app.Run();

async Task SeedDataAsync()
{
    if (await DB.CountAsync<ImageModel>() == 0)
    {
        await new ImageModel { Name = "Image 1", Url = "http://example.com/img1.jpg" }.SaveAsync();
        await new ImageModel { Name = "Image 2", Url = "http://example.com/img2.jpg" }.SaveAsync();
    }
}
