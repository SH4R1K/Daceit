using DaceItFront.Data;
using DaceItFront.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

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

            builder.Services.AddIdentity<Player, IdentityRole>()
                .AddEntityFrameworkStores<DaceitContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews();
            
            builder.Services.AddRazorPages(); // �������� ��� ������

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // �������� ��� ������
            app.UseAuthorization(); // � ��� ������

            app.MapRazorPages(); // ��� ������ ���� ���������
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Hub}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
