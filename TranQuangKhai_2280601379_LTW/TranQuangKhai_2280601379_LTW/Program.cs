using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TranQuangKhai_2280601379_LTW.Models;
using TranQuangKhai_2280601379_LTW.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ========== CẤU HÌNH DỊCH VỤ ==========

// ✅ MySQL - EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36)) // Điều chỉnh version theo máy bạn
    )
);

// ✅ Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// ✅ Razor Pages + MVC
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// ✅ Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ✅ Repositories
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

// ========== CẤU HÌNH ỨNG DỤNG ==========
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ✅ Load file từ wwwroot

app.UseRouting();

app.UseSession();        // ✅ Bắt buộc nếu dùng Session
app.UseAuthentication(); // ✅ Quan trọng nếu dùng Identity
app.UseAuthorization();

// Razor Pages cho Identity UI
app.MapRazorPages();

// ✅ Tuyến đường cho Areas (Admin)
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

    // ✅ Tuyến đường mặc định
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Product}/{action=Index}/{id?}"
    );
});

app.Run();
