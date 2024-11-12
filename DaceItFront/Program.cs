using DaceItFront.Data;
using Microsoft.EntityFrameworkCore;

namespace DaceItFront
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            
            builder.Services.AddDbContext<DaceitContext>(options =>
            {
                options.UseMySQL(builder.Configuration.GetConnectionString("mysqlconnstring"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline. s
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Hub}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
