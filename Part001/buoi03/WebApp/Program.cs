using Microsoft.EntityFrameworkCore;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

//trend VN
builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddDbContext<StoreContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("Store")));
builder.Services.AddMvc();
var app = builder.Build();
app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();

app.Run();
