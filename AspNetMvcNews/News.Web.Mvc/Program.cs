using Microsoft.AspNetCore.Authentication.Cookies;
using News.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDalServices(builder.Configuration);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opts =>
    {
        opts.Cookie.Name = "News.auth";
        opts.ExpireTimeSpan = TimeSpan.FromDays(7);
        opts.SlidingExpiration = false;   //true; //kulland?kca 7 gün a?ar
        opts.LoginPath = "/Auth/Login";
        opts.LogoutPath = "/Auth/Logout";
        opts.AccessDeniedPath = "/Home/AccessDenied"; //yetkilendirme,
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
