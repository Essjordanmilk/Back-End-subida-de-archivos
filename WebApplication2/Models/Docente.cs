using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Docente
    {
        public int IdDoc { get; set; }
        public string NombreDoc { get; set; } = null!;
        public string Facultad { get; set; } = null!;
    }
}
