using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pop_Dan_Ioan_LAB2.Areas.Identity.Data;
using Pop_Dan_Ioan_LAB2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Pop_Dan_Ioan_LAB2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pop_Dan_Ioan_LAB2Context") ?? throw new InvalidOperationException("Connection string 'Pop_Dan_Ioan_LAB2Context' not found.")));


builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pop_Dan_Ioan_LAB2Context") ?? throw new InvalidOperationException("Connection string 'Pop_Dan_Ioan_LAB2Context' not found.")));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("Admin"));
});


builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Publishers", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Categories", "AdminPolicy");
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();