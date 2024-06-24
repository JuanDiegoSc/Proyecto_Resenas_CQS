﻿using System;
using System.Collections.Generic;

namespace Resena_API.Data.Models;

public partial class Slider
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public string? UrlImagen { get; set; }
}
