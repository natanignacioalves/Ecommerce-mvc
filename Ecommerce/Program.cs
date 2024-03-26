using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Data Source=NATAN\\SQLEXPRESS;Initial Catalog=ECOMMERCE;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

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

/*
app.MapControllerRoute(
    name: "vendas",
    pattern: "vendas/{action}/{id?}",
    defaults: new { controller = "Vendas", action = "Index" });
*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vendas}/{action=Index}/{id?}");

app.Run();
