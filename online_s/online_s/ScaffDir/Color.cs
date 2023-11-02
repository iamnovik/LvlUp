using System;
using System.Collections.Generic;

namespace online_s.ScaffDir;

public partial class Color
{
    public short ColorId { get; set; }

    public string? ColorName { get; set; }

    public virtual ICollection<M2mProductSizeColor> M2mProductSizeColors { get; set; } = new List<M2mProductSizeColor>();
}
