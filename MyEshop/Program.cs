using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyEshop.Data;
using MyEshop.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

#region Db Context
builder.Services.AddDbContext<MyEshopContext>(options =>
   options.UseSqlServer("Data Source=ILIYA\\SQL2022;Initial Catalog=EshopCore_DB;Integrated Security=True;TrustServerCertificate=True"));
#endregion

#region IoC
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseStaticFiles();  //This line is required for serving static files (CSS, JS)
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();
