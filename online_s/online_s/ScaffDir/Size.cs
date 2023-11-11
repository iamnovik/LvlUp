using System;
using System.Collections.Generic;

namespace online_s.ScaffDir;

public partial class Size
{
    public int SizeId { get; set; }

    public string SizeName { get; set; } = null!;

    public virtual ICollection<M2mProductSizeColor> M2mProductSizeColors { get; set; } = new List<M2mProductSizeColor>();
}
