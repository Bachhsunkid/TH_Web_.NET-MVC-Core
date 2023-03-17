using System;
using System.Collections.Generic;

namespace TH_Ogani_Test.Models;

public partial class TChatLieu
{
    public string MaChatLieu { get; set; } = null!;

    public string? ChatLieu { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; } = new List<TDanhMucSp>();
}
