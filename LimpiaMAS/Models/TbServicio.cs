using System;
using System.Collections.Generic;

namespace LimpiaMAS.Models;

public partial class TbServicio
{
    public string IdServ { get; set; } = null!;

    public string CatServ { get; set; } = null!;

    public DateTime FecServ { get; set; }

    public decimal PreServ { get; set; }

    public string IdCli { get; set; } = null!;

    public Guid? Guidserv { get; set; }

    public TimeSpan? HoraServ { get; set; }

    public virtual TbCliente IdCliNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleservicio> TbDetalleservicios { get; set; } = new List<TbDetalleservicio>();
}
