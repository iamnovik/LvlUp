using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models.ScaffDir;
using OnlineShop.Validators;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;
using WebApplicationBuilder = Microsoft.AspNetCore.Builder.WebApplicationBuilder;
namespace OnlineShop;

public class Program
{
    public static void Main(String[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        
        var connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ShopDbContext>(options => options.UseNpgsql(connection));
        
        builder.Services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BrandValidator>());
        
        WebApplication app = builder.Build();
        app.UseRouting();
        app.Map("/", () => "Index Page");
        app.Run();

    }
}