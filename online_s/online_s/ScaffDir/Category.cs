﻿using System;
using System.Collections.Generic;

namespace online_s.ScaffDir;

public partial class Category
{
    public long CategoryId { get; set; }

    public long? CategorySubcategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual Category? CategorySubcategory { get; set; }

    public virtual ICollection<Category> InverseCategorySubcategory { get; set; } = new List<Category>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}