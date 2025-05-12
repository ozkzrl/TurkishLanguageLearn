var builder = WebApplication.CreateBuilder(args);

// Session ve di�er servisleri ekle
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session s�resi
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Session'� kullan�ma a�
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=kelimesec}/{action=Index}/{id?}");

app.Run();

