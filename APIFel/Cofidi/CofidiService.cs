using APIFel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace APIFel.Cofidi
{
    public class CofidiService
    {
        public static Response<wsCofidi.TransactionTag> CertificarDocumento(string llaveGeneral, string usuario, string endpoint, string pais, string nit, string xml_dte, string identificador)
        {
            EndpointAddress address =
               new EndpointAddress("https://portal.cofidiguatemala.com/webservicefrontfeltest/factwsfront.asmx");
            WSHttpBinding binding = new WSHttpBinding();
            wsCofidi.FactWSFrontSoapClient factWSFrontSoap = new wsCofidi.FactWSFrontSoapClient(binding, address);
            Response<wsCofidi.TransactionTag> response = new Response<wsCofidi.TransactionTag>();
            try
            {
                byte[] toDecodeByte = Encoding.UTF8.GetBytes(xml_dte);
                var xml_64based = Convert.ToBase64String(toDecodeByte);
                var responseCofidi = factWSFrontSoap.RequestTransaction(llaveGeneral,
                   "SYSTEM_REQUEST",
                   pais,
                   nit,
                   llaveGeneral,
                   usuario,
                   endpoint,
                   xml_64based,
                   identificador);
                if (responseCofidi.Response.Result)
                {
                    response.Success = true;
                    response.Object = responseCofidi;
                }
                else
                {
                    response.Success = false;
                    response.Message = responseCofidi.Response.Description;
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

    }
}
