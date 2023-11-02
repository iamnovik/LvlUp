using System;
using System.Collections.Generic;

namespace online_s.ScaffDir;

public partial class Adress
{
    public long AddressId { get; set; }

    public long AddressUserId { get; set; }

    public string AddressAddress { get; set; } = null!;

    public virtual User AddressUser { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
