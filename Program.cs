using FarmerCentral2.Data;
using FarmerCentral2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
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
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();


        //Creating Roles
        using (var scope = app.Services.CreateScope())
        {
            var roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //creating roloes
            var roles = new[] { "Farmer", "Employee" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        //Adding Employee User
        using (var scope = app.Services.CreateScope())
        {
            var userManager =
                scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string email = "employee1@employee.com";
            string password = "Employee123!";

            //if employee user does not exist, it will create it and assign it to the "Employee" role
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser();
                user.UserName = email;
                user.Email = email;

                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, "Employee");
            }
        }

        //Farmer
        using (var scope = app.Services.CreateScope())
        {
            var userManager =
                scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string email = "farmer@farmer.com";
            string password = "Farmer123!";

            //if employee user does not exist, it will create it and assign it to the "Employee" role
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser();
                user.UserName = email;
                user.Email = email;

                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, "Farmer");
            }
        }

        //Farmer1
        using (var scope = app.Services.CreateScope())
        {
            var userManager =
                scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string email = "farmer1@farmer.com";
            string password = "Farmer123!";

            //if employee user does not exist, it will create it and assign it to the "Employee" role
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser();
                user.UserName = email;
                user.Email = email;

                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, "Farmer");
            }
        }

        //Farmer2
        using (var scope = app.Services.CreateScope())
        {
            var userManager =
                scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string email = "farmer2@farmer.com";
            string password = "Farmer123!";

            //if employee user does not exist, it will create it and assign it to the "Employee" role
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser();
                user.UserName = email;
                user.Email = email;

                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, "Farmer");
            }
        }

        app.Run();
    }
}
