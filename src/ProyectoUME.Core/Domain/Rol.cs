using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Rol
    {
        public Rol()
        {
            Excusa = new HashSet<Excusa>();
            Permiso = new HashSet<Permiso>();
            Proyecto = new HashSet<Proyecto>();
            TurnoLaboral = new HashSet<TurnoLaboral>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        public virtual ICollection<Excusa> Excusa { get; set; }
        public virtual ICollection<Permiso> Permiso { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
        public virtual ICollection<TurnoLaboral> TurnoLaboral { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
