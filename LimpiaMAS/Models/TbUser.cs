using System;
using System.Collections.Generic;

namespace LimpiaMAS.Models;

public partial class TbUser
{
    public string Usr { get; set; } = null!;

    public string Pwd { get; set; } = null!;

    public virtual ICollection<TbCliente> TbClientes { get; set; } = new List<TbCliente>();

    public virtual ICollection<TbLimpiador> TbLimpiadors { get; set; } = new List<TbLimpiador>();
}
