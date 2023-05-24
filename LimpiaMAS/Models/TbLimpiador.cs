using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace LimpiaMAS.Models;

public partial class TbLimpiador
{
    public string IdLimp { get; set; } = null!;

    public string NomLimp { get; set; } = null!;

    public string ApeLimp { get; set; } = null!;

    public string DirLimp { get; set; } = null!;

    public string TelLimp { get; set; } = null!;

    public string DisLimp { get; set; } = null!;

    public decimal TarLimp { get; set; }

    public byte[] FotLimp { get; set; } = null!;

    public string Usr { get; set; } = null!;

    public string Etiqueta { get; set; } = null!;

    public string Pwd { get; set; } = null!;

    public virtual TbDetalledi? TbDetalledi { get; set; }

    public virtual ICollection<TbServicio> TbServicios { get; set; } = new List<TbServicio>();
}
