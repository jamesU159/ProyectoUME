using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Documentos
    {
        public int IdTramiteD { get; set; }
        public DateTime? Fecha { get; set; }
        public string CursoAltura { get; set; }
        public string CertificadoEps { get; set; }
        public string CertificadoArl { get; set; }
        public string CertificadoPensiones { get; set; }
        public string HojaVida { get; set; }
    }
}
