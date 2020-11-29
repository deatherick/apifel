using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFel.Model
{
    public class CertificarDocumento
    {
        public Documento documento { get; set; }
        public ParametrosFirma parametrosFirma { get; set; }
    }
}
