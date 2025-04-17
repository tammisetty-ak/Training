using Microsoft.EntityFrameworkCore;
using MovieShopCore.Contracts.Repositories;
using MovieShopCore.Contracts.Services;
using MovieShopCore.Entities;
using MovieShopInfrastructure.Data;
using MovieShopInfrastructure.Repositories;
using MovieShopInfrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddScoped<IRepository<Genre>, BaseRepository<Genre>>();

builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddScoped<ICastService, CastService>();

builder.Services.AddScoped<ICastRepository, CastRepository>();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddDbContext<MovieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopDbConnection"));
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();