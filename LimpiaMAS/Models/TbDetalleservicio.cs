using System;
using System.Collections.Generic;

namespace LimpiaMAS.Models;

public partial class TbDetalleservicio
{
    public string IdDetserv { get; set; } = null!;

    public string? IdServ { get; set; }

    public string IdCli { get; set; } = null!;

    public string CatServ { get; set; } = null!;

    public DateTime FecServ { get; set; }

    public TimeSpan DurServ { get; set; }

    public decimal ImpServ { get; set; }

    public TimeSpan HoraServ { get; set; }

    public string NomapeCli { get; set; } = null!;

    public string DirCli { get; set; } = null!;

    public string NomapeLim { get; set; } = null!;

    public virtual TbCliente IdCliNavigation { get; set; } = null!;

    public virtual TbServicio? IdServNavigation { get; set; }
}
