using System;
using System.Collections.Generic;

namespace TH_Ogani_Test.Models;

public partial class TLoaiDt
{
    public string MaDt { get; set; } = null!;

    public string? TenLoai { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; } = new List<TDanhMucSp>();
}
