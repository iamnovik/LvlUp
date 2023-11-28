using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models.ScaffDir;
using OnlineShop.Validators;
namespace OnlineShop;

public class Program
{
    public static void Main(String[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ShopDbContext>(options => options.UseNpgsql(connection));
        
        builder.Services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BrandValidator>());
        
        var app = builder.Build();
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        

    }
}