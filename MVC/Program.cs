using AutoMapper;
using BLL.Mapping;
using BLL.Services.Abstracts;
using BLL.Services.Concretes;
using DAL.Context;
using DAL.Repositories.Abstracts;
using DAL.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
using MVC.UiMappingProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//DbContext Configuration
builder.Services.AddDbContext<HRContext>(options =>
    options.UseSqlServer(connectionString));

//Repository services configuration
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

//BLL services configuration
builder.Services.AddScoped<IPersonelService, PersonelService>();
builder.Services.AddScoped<IGorevYeriService, GorevYeriService>();

//Mapping service configuration
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(UiMappingProfile));

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "dashboard",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
