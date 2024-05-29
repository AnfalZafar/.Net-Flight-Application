using Flight.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Xml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<flightContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    ox =>
    {
        ox.LoginPath = ("/Home/Login");
        ox.AccessDeniedPath = ("/Home/Login");
    }
);
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromSeconds(1800);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;

	}
) ;

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
