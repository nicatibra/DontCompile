using CompileCrew.DAL;
using CompileCrew.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CompileCrew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 6; //parolun min uzunlugu
                opt.Password.RequireNonAlphanumeric = false; //

                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._@";//username-de istifade oluna bilecek simvollar
                opt.User.RequireUniqueEmail = true; //1 mail 1 profil ucun olur


            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders(); ;



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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}"
    );


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}"
                );


            app.Run();
        }
    }
}
