using APIFel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace APIFel.Services
{
    [ServiceContract]
    public interface ICertificarDocumentoService
    {
        [OperationContract]
        Response<string> CertificarDocumento(CertificarDocumento certificarDocumento);
    }
}
