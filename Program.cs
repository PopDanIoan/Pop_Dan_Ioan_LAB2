using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pop_Dan_Ioan_LAB2.Areas.Identity.Data;
using Pop_Dan_Ioan_LAB2.Data;

var builder = WebApplication.CreateBuilder(args);

// Adaugă DbContext-ul principal al aplicației
builder.Services.AddDbContext<Pop_Dan_Ioan_LAB2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pop_Dan_Ioan_LAB2Context") ?? throw new InvalidOperationException("Connection string 'Pop_Dan_Ioan_LAB2Context' not found.")));

// Adaugă DbContext-ul pentru Identity, folosind același connection string
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pop_Dan_Ioan_LAB2Context") ?? throw new InvalidOperationException("Connection string 'Pop_Dan_Ioan_LAB2Context' not found.")));

// Adaugă serviciile Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Adaugă Authentication (crucial pentru Identity)
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();