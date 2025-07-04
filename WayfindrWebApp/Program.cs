using Microsoft.EntityFrameworkCore;
using WayfindrWebApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=C:\\Users\\ldenr\\OneDrive\\Desktop\\database\\yourdatabasefile.db"));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.UseSession();

app.Run();
