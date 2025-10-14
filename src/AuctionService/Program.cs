using System.Reflection;
using AuctionService.Data;
using AuctionService.RequestHelpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AuctionDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// TODO: Pray that this works
builder.Services.AddAutoMapper((action) => {
    action.AddProfile<MappingProfiles>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();

try
{
    DbInitializer.InitDb(app);
}
catch (Exception ex)
{
    Console.WriteLine($"Error during DB init: {ex.Message}");
}

app.Run();
