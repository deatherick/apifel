using System;
using APIFel.Model;
using APIFel.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIFel.Controllers
{
    [ApiController]
    [Route("ApiFel")]
    public class GeneraXmlController : ControllerBase, IGenerarXmlService
    {
        private readonly GeneraXmlService service = new GeneraXmlService();

        [HttpGet("GeneraXML")]
        public IActionResult Index()
        {
            return NotFound();
        }

        [HttpPost("GeneraXML")]
        public IActionResult GeneraXMLRest(Documento documento)
        {
            try
            {
                var response = service.GeneraXML(documento);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public Response<string> GeneraXMLSoap(Documento documento)
        {
            var response = service.GeneraXML(documento);
            return response;
        }
    }
}
