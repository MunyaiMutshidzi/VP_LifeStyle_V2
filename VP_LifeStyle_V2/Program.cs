using VP_Lifestyle.Data;
using Microsoft.EntityFrameworkCore;
using VP_LifeStyle_V2.Data;
using VP_LifeStyle_V2.Infrastructure;
using Microsoft.AspNetCore.Identity;
using VP_LifeStyle_V2.Models;
var builder = WebApplication.CreateBuilder(args);

///Add services
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ILifestyleRepository, LifestyleRepository>();

//When using Microsoft.EntityFramwork use it's wrappers
builder.Services.AddScoped<IRespositoryWrapper,RespositoryWrapper>();
//Database Option 1 :SQl Server
builder.Services.AddDbContext<LifestyleDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("VPConnection")));

//Database option 2: SQL Lite Server
//builder.Services.AddDbContext<AppDbContext>(options =>
//       options.UseSqlite(builder.Configuration.GetConnectionString("VPConnection")));

//When using a different DbContext(LifestyleIdentityDbContext)
//SeedIdentity(data) should be stored on it's own database and should use Different contection & Database names

//Database Option 1: SQL Server
builder.Services.AddDbContext<LifeStyleIdentityDbContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("VPIdentityConnection")));
//Database Option 2: SQL Lite Server
//builder.Services.AddDbContext<LifeStyleIdentityDbContext>(options =>
//        options.UseSqlite(builder.Configuration.GetConnectionString("VPIdentityConnection")));

// Ensure you register ASP.NET Core Identity (when using a different DbIdentityContext)
//to enable the use of (UserManager<AppUser> ) &  RoleManager<IdentityRole>
builder.Services.AddIdentity<AppUser, IdentityRole>(opts =>
 { //Adding password settings
       opts.Password.RequiredLength = 5;//Minimum length
     opts.Password.RequireDigit = true;
     opts.Password.RequireNonAlphanumeric = true;   
     opts.User.RequireUniqueEmail = true;
 }) .AddEntityFrameworkStores<LifeStyleIdentityDbContext>();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

builder.Services.AddScoped<IPasswordValidator<AppUser>, CustomValidator>();
var app = builder.Build();

//configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: default,
    pattern: "{controller=Restoran}/{action=Index}/{id?}"
    );
SeedData.EnsurePopulated(app);
SeedIdentityData.SeedIdentity(app);
app.Run();
