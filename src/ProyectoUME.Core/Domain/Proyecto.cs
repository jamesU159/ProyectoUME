using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            ListaEmpleados = new HashSet<ListaEmpleados>();
        }

        public int CodigoProyecto { get; set; }
        public int? NumeroEmpleados { get; set; }
        public string DireccionProyecto { get; set; }
        public string PersonaResponsable { get; set; }

        public virtual ICollection<ListaEmpleados> ListaEmpleados { get; set; }
    }
}
