using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Excusas
    {
        public int NumeroReferencia { get; set; }
        public string AnexoEvidencia { get; set; }
        public int? IdAdministrador { get; set; }
        public int IdObrero { get; set; }
        public string Nombre1Usuario { get; set; }
        public string Nombre2Usuario { get; set; }
        public string Apellido1Usuario { get; set; }
        public string Apellido2Usuario { get; set; }
        public string Correo { get; set; }
        public double? Telefono { get; set; }
        public int? CodigoProyecto { get; set; }

        public virtual Administrador IdAdministradorNavigation { get; set; }
        public virtual Obrero IdObreroNavigation { get; set; }
    }
}
