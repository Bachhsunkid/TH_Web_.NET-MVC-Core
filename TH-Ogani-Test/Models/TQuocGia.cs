using System;
using System.Collections.Generic;

namespace TH_Ogani_Test.Models;

public partial class TQuocGia
{
    public string MaNuoc { get; set; } = null!;

    public string? TenNuoc { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; } = new List<TDanhMucSp>();
}
