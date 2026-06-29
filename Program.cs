using GSULibrary.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GSUBookContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GSUBookContext")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GSUBookContext>();

    context.Database.EnsureCreated();

    if (!context.Books.Any())
    {
        context.Books.AddRange(
            new GSUBook
            {
                Name = "Database Systems",
                Author = "Carlos Coronel",
                ISBN = "9781337627900",
                Price = 89.99m,
                NumberOfCopy = 5
            },
            new GSUBook
            {
                Name = "Clean Code",
                Author = "Robert C. Martin",
                ISBN = "9780132350884",
                Price = 45.50m,
                NumberOfCopy = 8
            },
            new GSUBook
            {
                Name = "ASP.NET Core MVC",
                Author = "Adam Freeman",
                ISBN = "9781484279564",
                Price = 59.99m,
                NumberOfCopy = 6
            }
        );

        context.SaveChanges();
    }
}
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

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
