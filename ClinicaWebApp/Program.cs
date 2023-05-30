using ClinicaWebApp.Data;
using DataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServicesLayer;
using ServicesLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var connString = builder.Configuration.GetConnectionString("ClinicaDbContext") ?? throw new InvalidOperationException("Connection string 'ClinicaDbContext' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ClinicaDbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Servizi Applicazione
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IAcceptanceService, AcceptanceService>();
builder.Services.AddScoped<IRecoveryService, RecoveryService>();
builder.Services.AddScoped<IExaminationService, ExaminationService>();

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

app.MapControllers();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
