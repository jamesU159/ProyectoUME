using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Empresa
    {
        public int Nit { get; set; }
        public string NombreEmpresa { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public double? Telefono { get; set; }
    }
}
