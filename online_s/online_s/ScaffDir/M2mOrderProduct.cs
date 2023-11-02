using System;
using System.Collections.Generic;

namespace online_s.ScaffDir;

public partial class M2mOrderProduct
{
    public long M2mOrderProductOrderId { get; set; }

    public long M2mOrderProductProductId { get; set; }

    public string? M2mOrderProductQuantity { get; set; }

    public virtual Order M2mOrderProductOrder { get; set; } = null!;

    public virtual M2mProductSizeColor M2mOrderProductProduct { get; set; } = null!;
}
