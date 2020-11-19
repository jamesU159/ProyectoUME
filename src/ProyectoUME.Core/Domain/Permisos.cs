using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Permisos
    {
        public int NumeroReferenciaPermiso { get; set; }
        public int? IdSupervisor { get; set; }
        public int IdObrero { get; set; }
        public int? CodigoProyecto { get; set; }
        public string Nombre1Usuario { get; set; }
        public string Nombre2Usuario { get; set; }
        public string Apellido1Usuario { get; set; }
        public string Apellido2Usuario { get; set; }
        public string Correo { get; set; }
        public double? Telefono { get; set; }

        public virtual Obrero IdObreroNavigation { get; set; }
        public virtual Supervisor IdSupervisorNavigation { get; set; }
    }
}
