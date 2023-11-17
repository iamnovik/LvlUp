using System;
using System.Collections.Generic;

namespace online_s.ScaffDir;

public partial class Cart
{
    public long CartUserId { get; set; }

    public long CartProductId { get; set; }

    public short? CartQuantity { get; set; }

    public virtual ProductVariant CartProduct { get; set; } = null!;

    public virtual User CartUser { get; set; } = null!;
}
