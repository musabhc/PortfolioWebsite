using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyPortfolioWebsite.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

// Adding DbContext
builder.Services.AddDbContext<PortfolioContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DbConnection"),
    new MySqlServerVersion(new Version(10, 5, 8))));

// Adding Identity and roles
builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PortfolioContext>()
    .AddDefaultUI()  
    .AddDefaultTokenProviders();

// Adding IConfiguration service
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<FileUploadService>();

var app = builder.Build();

// Creating admin role at the startup
CreateAdminRoleAndAssignUser(app).Wait();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Create admin role and assign user
async Task CreateAdminRoleAndAssignUser(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // check if the role exists, if not create it
        var roleExist = await roleManager.RoleExistsAsync("Admin");
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // find the user by email and assign the role
        var user = await userManager.FindByEmailAsync("mbhc4235@gmail.com"); // Kendi e-posta adresini buraya yaz
        if (user != null)
        {
            var isInRole = await userManager.IsInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
