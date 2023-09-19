
using InzBlogging.Data;
using InzBlogging.Repository;
using InzBlogging.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InzBloggingContext>(options =>
{ 
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
},ServiceLifetime.Transient);
builder.Services.AddTransient<IUserAccount, UserAccountRepository>(p => new UserAccountRepository(builder.Services.BuildServiceProvider().GetService<InzBloggingContext>()));
builder.Services.AddTransient<IUser, UserRepository>(p => new UserRepository(builder.Services.BuildServiceProvider().GetService<InzBloggingContext>()));
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
