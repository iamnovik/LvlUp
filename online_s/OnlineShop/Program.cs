using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using online_s.ScaffDir;
using online_s;

public class Program
{
    async Task<IEnumerable<Product>> GetAllProductsByBrand(ShopDbContext dbContext, Brand brand)
    {
        var products = await dbContext.Products
            .Include(p => p.ProductBrand)
            .Where(p => p.ProductBrand.BrandName == brand.BrandName)
            .ToListAsync(); // Use ToListAsync for asynchronous execution

        return products;
    }
    async Task<Dictionary<Brand, int>> GetBrandProductCounts(ShopDbContext dbContext)
    {
        var brands = await dbContext.Brands.Include(b => b.Products).ToListAsync();
        var dict = new Dictionary<Brand, int>();
        foreach (var item in brands)
        {
            dict.Add(item, item.Products.Count);
        }

        return dict;
    }

    async Task<IEnumerable<ProductVariant>> GetProductVariants(ShopDbContext dbContext, long pId)
    {
        return (await dbContext.Products
                .Where(p => p.ProductId == pId)
                .Include(p => p.ProductVariants)
                .FirstAsync())
            .ProductVariants
            .OrderBy(p => p.pvProduct.ProductName)
            .ToList();
    }

    async Task<IEnumerable<Product>> GetProductBySectionAndCategory(ShopDbContext dbContext, long sectionId,
        long categoryId)
    {
        /*var results = await dbContext.Products
            .Join(dbContext.M2mSectionCategories, p => p.ProductCategoryId, m => m.M2mSectionCategoryCategoryId, (p, m) => new { Product = p, M2mSectionCategory = m })
            .Join(dbContext.Sections, pm => pm.M2mSectionCategory.M2mSectionCategorySectionId, s => s.SectionId, (pm, s) => new { pm.Product, pm.M2mSectionCategory, Section = s })
            .Join(dbContext.Categories, pms => pms.M2mSectionCategory.M2mSectionCategoryCategoryId, c => c.CategoryId, (pms, c) => new { pms.Product, pms.M2mSectionCategory, pms.Section, Category = c })
            .Where(result => result.Section.SectionId == sectionId && result.Category.CategoryId == categoryId)
            .Select(result => result.Product)
            .ToListAsync();
        */
        return null;

    }
    async Task<IEnumerable<Review>> GetReviewsByProductName(ShopDbContext dbContext, string productName)
    {
        var reviews = await dbContext.Products.Include(p => p.Reviews).FirstOrDefaultAsync(p => p.ProductName == productName);
        if (reviews != null)
        {
            return reviews.Reviews;
        }
        return Enumerable.Empty<Review>();
    }
    async Task<IEnumerable<Order>> GetOrdersByProductAndStatus(ShopDbContext dbContext, int productId, int orderStatus)
    {

        var results = await dbContext.Orders
            .OrderByDescending(o => o.OrderTimeCreate)
            .Join(dbContext.M2mOrderProducts, o => o.OrderId, m => m.OrderProductOrderId, (o, m) => new { Order = o, OrderProduct = m })
            .Join(dbContext.ProductVariants, om => om.OrderProduct.OrderProductProductId, psc => psc.pvId, (om, psc) => new { om.Order, om.OrderProduct, ProductSizeColor = psc })
            .Where(result => result.ProductSizeColor.pvProductId == productId && result.Order.OrderStatus == orderStatus)
            .Select(result => result.Order)
            .ToListAsync();

        return results;
    }
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
    }

    public static void Main(String[] args)
    {
        
        CreateHostBuilder(args).Build().Run();

    }
}






