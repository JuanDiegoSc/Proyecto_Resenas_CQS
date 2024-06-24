using System;
using System.Collections.Generic;

namespace Resena_API.Data.Models;

public partial class Categorium
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Orden { get; set; }

    public virtual ICollection<Juego> Juegos { get; set; } = new List<Juego>();
}
