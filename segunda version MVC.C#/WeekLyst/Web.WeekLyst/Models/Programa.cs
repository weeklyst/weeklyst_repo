using System;
using System.Collections.Generic;

#nullable disable

namespace Web.WeekLyst.Models
{
    public partial class Programa
    {
        public int ProgramaId { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }
    }
}
