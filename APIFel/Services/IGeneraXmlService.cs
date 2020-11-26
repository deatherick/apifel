using APIFel.Model;
using System.ServiceModel;

namespace APIFel.Services
{
    [ServiceContract]
    public interface IGenerarXmlService
    {
        [OperationContract]
        Response<string> GeneraXML(Documento documento);
    }
}
