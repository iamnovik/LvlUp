using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using online_s.ScaffDir;
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
    var brands =await dbContext.Brands.Include(b => b.Products).ToListAsync();
    var dict = new Dictionary<Brand, int>();
    foreach (var item in brands)
    {
        dict.Add(item,item.Products.Count);
    }

    return dict;
}

async Task<IEnumerable<M2mProductSizeColor>> GetProductVariants(ShopDbContext dbContext, long pId)
{
    return (await dbContext.Products
            .Where(p => p.ProductId == pId)
            .Include(p => p.M2mProductSizeColors)
            .FirstAsync())
        .M2mProductSizeColors
        .OrderBy(p => p.M2mPscProduct.ProductName)
        .ToList();
}

async Task<IEnumerable<Product>> GetProductBySectionAndCategory(ShopDbContext dbContext, long sectionId,
    long categoryId)
{
    var results = await dbContext.Products
        .Join(dbContext.M2mSectionCategories, p => p.ProductCategoryId, m => m.M2mSectionCategoryCategoryId, (p, m) => new { Product = p, M2mSectionCategory = m })
        .Join(dbContext.Sections, pm => pm.M2mSectionCategory.M2mSectionCategorySectionId, s => s.SectionId, (pm, s) => new { pm.Product, pm.M2mSectionCategory, Section = s })
        .Join(dbContext.Categories, pms => pms.M2mSectionCategory.M2mSectionCategoryCategoryId, c => c.CategoryId, (pms, c) => new { pms.Product, pms.M2mSectionCategory, pms.Section, Category = c })
        .Where(result => result.Section.SectionId == sectionId && result.Category.CategoryId == categoryId)
        .Select(result => result.Product)
        .ToListAsync();

    return results;
    
}
async Task<IEnumerable<Review>> GetReviewsByProductName(ShopDbContext dbContext, string productName)
{ 
    var reviews = await dbContext.Products.Include(p => p.Reviews).FirstOrDefaultAsync(p => p.ProductName == productName);
    if (reviews != null)
    {
        return reviews.Reviews;
    }
    return   Enumerable.Empty<Review>();
}
async Task<IEnumerable<Order>> GetOrdersByProductAndStatus(ShopDbContext dbContext, int productId, int orderStatus)
{
    
    var results = await dbContext.Orders
        .OrderByDescending(o => o.OrderTimeCreate)
        .Join(dbContext.M2mOrderProducts, o => o.OrderId, m => m.M2mOrderProductOrderId, (o, m) => new { Order = o, OrderProduct = m })
        .Join(dbContext.M2mProductSizeColors, om => om.OrderProduct.M2mOrderProductProductId, psc => psc.M2mPscId, (om, psc) => new { om.Order, om.OrderProduct, ProductSizeColor = psc })
        .Where(result => result.ProductSizeColor.M2mPscProductId == productId && result.Order.OrderStatus == orderStatus)
        .Select(result => result.Order)
        .ToListAsync();

    return results;
}





