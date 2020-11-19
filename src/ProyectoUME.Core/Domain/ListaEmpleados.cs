using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class ListaEmpleados
    {
        public int NConsulta { get; set; }
        public int CodigoProyecto { get; set; }

        public virtual Proyecto CodigoProyectoNavigation { get; set; }
    }
}
