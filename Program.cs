using MenusDinamicos.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<JquerytablebasicContext>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(op =>
{
    op.IdleTimeout = TimeSpan.FromMinutes(10);
    op.Cookie.HttpOnly = true;
    op.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
