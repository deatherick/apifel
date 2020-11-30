using APIFel.Model;
using System.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace APIFel.Services
{
    [ServiceContract]
    public interface IGenerarXmlService
    {
        IActionResult GeneraXMLRest(Documento documento);

        [OperationContract(Name = "GeneraXML")]
        Response<string> GeneraXMLSoap(Documento documento);
    }
}
