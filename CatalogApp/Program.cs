using CatalogApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

services.AddRazorPages();

var useInMemory = configuration.GetValue<bool>("UseInMemory");
if (useInMemory)
{
    services.AddDbContext<BookContext>(
        options => 
            options.UseInMemoryDatabase(databaseName: "redit_db_in_memory"));
}else{
    services.AddDbContext<BookContext>(
        options => 
            options.UseSqlServer(configuration.GetConnectionString("BooksDB")));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
