﻿namespace OnlineShop.Models.ScaffDir;

public class Size
{
    public int SizeId { get; set; }

    public string SizeName { get; set; } = null!;

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
