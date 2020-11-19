using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Obrero
    {
        public Obrero()
        {
            Excusas = new HashSet<Excusas>();
            Permisos = new HashSet<Permisos>();
        }

        public int IdObrero { get; set; }
        public int NumeroCedula { get; set; }
        public string Nombre1O { get; set; }
        public string Apellido1O { get; set; }

        public virtual Usuario NumeroCedulaNavigation { get; set; }
        public virtual ICollection<Excusas> Excusas { get; set; }
        public virtual ICollection<Permisos> Permisos { get; set; }
    }
}
