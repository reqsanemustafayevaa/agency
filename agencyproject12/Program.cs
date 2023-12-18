using Microsoft.EntityFrameworkCore;
using project.business.Services.Implementations;
using project.business.Services.Interfaces;
using project.Core.Repositories.Interfaces;
using project.data.DAL;
using project.data.Repostories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPortifolioRepostory, PortifolioRepostory>();
builder.Services.AddScoped<IPortifolioService,PortifolioService>();
builder.Services.AddScoped<ICategoryRepostory, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();    
builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseSqlServer("server=DESKTOP-Q400V6O\\SQLEXPRESS;database=agencyproject;Trusted_Connection=True");

});

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
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
