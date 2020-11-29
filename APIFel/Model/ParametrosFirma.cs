using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFel.Model
{
    public class ParametrosFirma
    {
        public string NombreCertificador { get; set; }
        public string Nit { get; set; }
        public string Prefijo { get; set; }
        public string LlaveGeneral { get; set; }
        public string LlaveCertificado { get; set; }
        public string CarpetaDTE { get; set; }
        public string Certificado { get; set; }
        public string CertificadoPassword { get; set; }
        public string URLCertificador { get; set; }
        public string URLAnulacion { get; set; }
        public string EndPointFirma { get; set; }
        public string EndPointAnularDoc { get; set; }
        public string EndPointPDF { get; set; }
        public string EndPointToken { get; set; }
        public string EndPointRegDoc { get; set; }
        public string CorreoEmisor { get; set; }
        public bool FirmaLocal { get; set; }
        public string CarpetaSucursal { get; set; }
    }
}
