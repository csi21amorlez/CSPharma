using DAL_CSPharma.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CspharmaInformacionalContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

builder.Services.AddDefaultIdentity<DAL_CSPharma.Models.DlkCatAccEmpleado>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DAL_CSPharma.Models.CspharmaInformacionalContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
