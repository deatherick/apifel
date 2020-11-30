using APIFel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIFel.Services
{
    [ServiceContract]
    public interface ICertificarDocumentoService
    {
        [OperationContract(Name = "CertificarDocumento")]
        Response<string> CertificarDocumento(CertificarDocumento certificarDocumento);
    }
}
