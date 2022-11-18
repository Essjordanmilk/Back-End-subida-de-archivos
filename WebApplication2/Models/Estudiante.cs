using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Estudiante
    {
        public int IdEstu { get; set; }
        public string NombreEstu { get; set; } = null!;
        public string Facultad { get; set; } = null!;
    }
}
