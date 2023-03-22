using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsRatings;
using SportsRatings.Interfaces;
using SportsRatings.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapperConfiguration));

builder.Services.AddScoped<ICategoryInterface, CategoryServices>();
builder.Services.AddScoped<ISportInterface, SportServices>();
builder.Services.AddScoped<TeamServices>();
//builder.Services.AddScoped<PlayerServices>();

builder.Services.AddDbContext<SrDbContext>(option => 
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
