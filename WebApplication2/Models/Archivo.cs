using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Archivo
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ubicacion { get; set; }
    }
}
