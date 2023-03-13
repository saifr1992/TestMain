using Microsoft.EntityFrameworkCore;
using TestMain.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("TestDbString"); // Database connection string comming from appsettings.json file.
builder.Services.AddDbContext<MyDatabaseContext>(options => options.UseSqlServer(connectionString)); // DB context of that connection string.

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Signup}/{id?}");

app.Run();

