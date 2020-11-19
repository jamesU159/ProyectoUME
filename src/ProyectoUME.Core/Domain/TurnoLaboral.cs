using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class TurnoLaboral
    {
        public int NumeroConsulta { get; set; }
        public int IdObrero { get; set; }
        public int? CodigoProyecto { get; set; }
        public string Jornada { get; set; }
    }
}
