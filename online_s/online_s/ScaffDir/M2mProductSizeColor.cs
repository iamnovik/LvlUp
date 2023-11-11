using System;
using System.Collections.Generic;

namespace online_s.ScaffDir;

public partial class M2mProductSizeColor
{
    public long M2mPscId { get; set; }

    public long M2mPscProductId { get; set; }

    public int M2mPscSizeId { get; set; }

    public short M2mPscColorId { get; set; }

    public int? M2mPscQuantity { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Color M2mPscColor { get; set; } = null!;

    public virtual Product M2mPscProduct { get; set; } = null!;

    public virtual Size M2mPscSize { get; set; } = null!;
}
