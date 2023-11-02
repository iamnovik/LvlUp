using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using online_s.ScaffDir;

using (var dbContext = new Shop_DbContext())
{
    //Update old data
    /*var BrandToUpdate = new Brand()
    {
        BrandId = 1,
        BrandName = "Arcteryx"
    };
    dbContext.Brands.Update(BrandToUpdate);
    dbContext.SaveChanges();*/
    //
    
    //Queries
    var products = dbContext.Products.Include(p => p.ProductBrand) // Если вы хотите получить информацию о бренде
        .Where(p => p.ProductBrand.BrandName == "B")
        .ToList();

    foreach (var product in products)
    {
        Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}");
    }
    
    var brandProductCounts = dbContext.Brands
        .GroupJoin(
            dbContext.Products,
            b => b.BrandId,
            p => p.ProductBrandId,
            (brand, products) => new
            {
                BrandName = brand.BrandName,
                NumProducts = products.Count()
            }
        )
        .OrderByDescending(result => result.NumProducts)
        .ToList();

    foreach (var result in brandProductCounts)
    {
        Console.WriteLine($"Brand: {result.BrandName}, Number of Products: {result.NumProducts}");
    }
    
    var query = from m in dbContext.M2mProductSizeColors
        join p in dbContext.Products on m.M2mPscProductId equals p.ProductId
        join b in dbContext.Brands on p.ProductBrandId equals b.BrandId
        where b.BrandName == "B"
        select new
        {
            M2MProductSizeColor = m,
            Product = p,
            Brand = b
        };

    var results = query.ToList();

    foreach (var result in results)
    {
        Console.WriteLine($"M2M_Product_Size_Color ID: {result.M2MProductSizeColor.M2mPscId}");
        //Console.WriteLine($"Size {0}, Color {1}",result.M2MProductSizeColor.M2mPscSize.SizeName,result.M2MProductSizeColor.M2mPscColor.ColorName);
        Console.WriteLine($"Product Name: {result.Product.ProductName}");
        Console.WriteLine($"Brand Name: {result.Brand.BrandName}");
    }
    
    var query2 = from p in dbContext.Products
        join m in dbContext.M2mSectionCategories on p.ProductCategoryId equals m.M2mSectionCategoryCategoryId
        join s in dbContext.Sections on m.M2mSectionCategorySectionId equals s.SectionId
        join c in dbContext.Categories on m.M2mSectionCategoryCategoryId equals c.CategoryId
        where s.SectionName == "Man" && c.CategoryName == "Sneakers"
        select p.ProductBrand.BrandName;
    var results2 = query2.ToList();
    foreach (var productName in results2)
    {
        Console.WriteLine($"Product Name: {productName}");
    }
    var query3 = from r in dbContext.Reviews
        join u in dbContext.Users on r.ReviewUserId equals u.UserId
        join p in dbContext.Products on r.ReviewProductId equals p.ProductId
        where p.ProductName == "B"
        select r;
    var results3 = query3.ToList();
    foreach (var result in results3)
    {
        Console.WriteLine($"Rating: {result.ReviewRating}, Comment: {result.ReviewComment}");
        Console.WriteLine($"UserID: {result.ReviewUserId},ReviewID: {result.ReviewId}");
    }

    var timeOrders = from o in dbContext.Orders.OrderByDescending(o => o.OrderTimeCreate)
        join m in dbContext.M2mOrderProducts on o.OrderId equals m.M2mOrderProductOrderId
        join psc in dbContext.M2mProductSizeColors on m.M2mOrderProductProductId equals psc.M2mPscId
        where psc.M2mPscProductId == 34 && o.OrderStatus == 1
        select o;
    var results4 = timeOrders.ToList();
    foreach (var result in results4)
    {
        Console.WriteLine($"OrderID: {result.OrderId}, Adress: {result.OrderAddress}");
        Console.WriteLine($"UserID: {result.OrderUserId},ReviewID: {result.OrderPrice}");
    }




}