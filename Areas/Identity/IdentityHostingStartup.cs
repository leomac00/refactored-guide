using System;
using desafioMVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DesafioMVC.Areas.Identity.IdentityHostingStartup))]
namespace DesafioMVC.Areas.Identity
{
  public class IdentityHostingStartup : IHostingStartup
  {
    public void Configure(IWebHostBuilder builder)
    {
      builder.ConfigureServices((context, services) =>
      {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                context.Configuration.GetConnectionString("ApplicationDbContextConnection")));
        //Não descomentar a proxima linha!!!
        /*services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
           .AddEntityFrameworkStores<ApplicationDbContext>();*/
      });
    }
  }
}