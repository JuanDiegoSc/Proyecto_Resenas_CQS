using System;
using System.Collections.Generic;

namespace Resena_API.Data.Models;

public partial class Resena
{
    public int Id { get; set; }

    public int Puntuacion { get; set; }

    public string Comentario { get; set; } = null!;

    public string? FechaResena { get; set; }

    public int JuegoId { get; set; }

    public virtual Juego Juego { get; set; } = null!;
}
