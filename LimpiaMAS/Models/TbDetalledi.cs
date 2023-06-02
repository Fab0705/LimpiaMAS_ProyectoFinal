using System;
using System.Collections.Generic;

namespace LimpiaMAS.Models;

public partial class TbDetalledi
{
    public string IdLimp { get; set; } = null!;

    public DateTime FecDet { get; set; }

    public TimeSpan TStart { get; set; }

    public TimeSpan TDone { get; set; }
}
