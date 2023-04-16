using System;
using System.Collections.Generic;

namespace MenusDinamicos.Models;

public partial class Documento
{
    public int IdDocumento { get; set; }

    public string? Descripcion { get; set; }

    public string? Ruta { get; set; }
}
