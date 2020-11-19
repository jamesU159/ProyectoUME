using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Administrador
    {
        public Administrador()
        {
            Excusas = new HashSet<Excusas>();
        }

        public int IdAdministrador { get; set; }
        public int? NumeroCedula { get; set; }
        public string Nombre1A { get; set; }
        public string Apellido1A { get; set; }

        public virtual Usuario NumeroCedulaNavigation { get; set; }
        public virtual ICollection<Excusas> Excusas { get; set; }
    }
}
