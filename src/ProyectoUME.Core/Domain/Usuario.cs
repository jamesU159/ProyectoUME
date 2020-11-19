using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            Administrador = new HashSet<Administrador>();
            Obrero = new HashSet<Obrero>();
            Supervisor = new HashSet<Supervisor>();
        }

        public int NumeroCedula { get; set; }
        public string PrimerNombreUsuario { get; set; }
        public string SegundoNombreUsuario { get; set; }
        public string PrimerApellidoUsuario { get; set; }
        public string SegundoApellidoUsuario { get; set; }
        public string Correo { get; set; }
        public int? IdRol { get; set; }
        public int? Edad { get; set; }
        public double? Telefono { get; set; }

        public virtual ICollection<Administrador> Administrador { get; set; }
        public virtual ICollection<Obrero> Obrero { get; set; }
        public virtual ICollection<Supervisor> Supervisor { get; set; }
    }
}
