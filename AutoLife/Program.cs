using AutoLife.Components;
using AutoLife.Data;
using AutoLife.Data.Repositories;
using AutoLife.Domain.Models;
using AutoLife.Lib.Interfaces;
using AutoLife.Lib.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<UserStateService>();
builder.Services.AddScoped<ToDoItemService>();
builder.Services.AddScoped<IRepository<UserProfile>, UserProfileRepository>();
builder.Services.AddScoped<IRepository<ToDoItem>, ToDoItemRepository>();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
