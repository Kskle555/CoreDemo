using DataAccesLayer.Concrete;
using EntityLayer.Concrete;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder => builder.AllowAnyMethod().AllowAnyHeader());
});
// Add services to the container.

builder.Services.AddControllersWithViews();

//Identity kodu
builder.Services.AddDbContext<Context>();
//Identity kodu
builder.Services.AddIdentity<AppUser, AppRole>(x => { x.Password.RequireUppercase = false; })
    .AddEntityFrameworkStores<Context>();


//Authorize kodu
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});


//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
//    options.Cookie.Name = "YourAppCookieName";
//    options.Cookie.HttpOnly = true;
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
//    options.LoginPath = "/Identity/Account/Login";
//    // ReturnUrlParameter requires 
//    //using Microsoft.AspNetCore.Authentication.Cookies;
//    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
//    options.SlidingExpiration = true;
//});

//Authorize return login url
builder.Services.AddMvc();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    }
);






var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}





app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1","?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

//Login iþlemi useauthentication
app.UseAuthentication();


app.UseRouting();

app.UseAuthorization();


app.UseCors("MyPolicy");

app.MapControllerRoute(
   name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
   

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
