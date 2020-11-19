using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Supervisor
    {
        public Supervisor()
        {
            Permisos = new HashSet<Permisos>();
        }

        public int IdSupervisor { get; set; }
        public int NumeroCedula { get; set; }
        public int Nombre1S { get; set; }
        public int Apellido1S { get; set; }

        public virtual Usuario NumeroCedulaNavigation { get; set; }
        public virtual ICollection<Permisos> Permisos { get; set; }
    }
}
