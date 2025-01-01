using BusinessLayer.Container;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FMailContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<FMailContext>().AddErrorDescriber<CustomIdentityErrorValidator>();

builder.Services.ContainerDependencies();

builder.Services.AddControllersWithViews().AddFluentValidation();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
