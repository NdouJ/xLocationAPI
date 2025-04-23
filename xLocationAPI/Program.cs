using Microsoft.AspNetCore.DataProtection.KeyManagement;
using xLocationAPI.Interfaces;
using xLocationAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HttpClient>();
string fourSquareApiKey = Environment.GetEnvironmentVariable("FOURSQUARE_API_KEY");
builder.Services.AddSingleton<IFoursquareService>(sp =>
{
    var foursquareBaseAddress = builder.Configuration["Foursquare:ApiBaseAddress"];
    if (string.IsNullOrEmpty(foursquareBaseAddress))
    {
        throw new InvalidOperationException("Foursquare base address is not set in the configuration.");
    }
    var httpClient = sp.GetRequiredService<HttpClient>();
    httpClient.BaseAddress = new Uri(foursquareBaseAddress);
    return new FoursquareService(fourSquareApiKey, httpClient);
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

app.MapControllers();

app.Run();
