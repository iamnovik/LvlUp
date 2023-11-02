using System;
using System.Collections.Generic;

namespace online_s.ScaffDir;

public partial class M2mSectionCategory
{
    public long M2mSectionCategorySectionId { get; set; }

    public long M2mSectionCategoryCategoryId { get; set; }

    public virtual Category M2mSectionCategoryCategory { get; set; } = null!;

    public virtual Section M2mSectionCategorySection { get; set; } = null!;
}
