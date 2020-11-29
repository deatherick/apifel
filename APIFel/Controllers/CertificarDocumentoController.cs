using APIFel.Model;
using APIFel.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFel.Controllers
{
    [ApiController]
    [Route("ApiFel")]
    public class CertificarDocumentoController : ControllerBase, ICertificarDocumentoService
    {
        [HttpGet("CertificarDocumento")]
        public Response<string> CertificarDocumento(CertificarDocumento certificarDocumento)
        {
            Response<string> response = new Response<string>();
            return response;

        }
    }
}
