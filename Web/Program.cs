using Infrastructure;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Web.Data;

var builder = WebApplication.CreateBuilder(args);
string mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");
string mongoDatabaseName = builder.Configuration["MongoDb:DatabaseName"];


builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(mongoConnectionString));
builder.Services.AddScoped(sp => new NoSqlDataContext(
    sp.GetRequiredService<IMongoClient>(),
    mongoDatabaseName
    ));

builder.Services.AddScoped(sp => new MongoUnitOfWork(
    sp.GetRequiredService<NoSqlDataContext>()
    ));

var CarRentalDb = builder.Configuration.GetConnectionString("CarRentalDb") ?? throw new InvalidOperationException("Connection string 'CarRentalDb' not found.");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(CarRentalDb));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
