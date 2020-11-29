using APIFel.Model;
using FirmaXadesNet.Signature.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace APIFel.Helper
{
    public class Certificado
    {
        public static Response<X509Certificate2> ObtenerCertificado(string cert64, string certificatePass)
        {
            Response<X509Certificate2> response = new Response<X509Certificate2>();
            try
            {
                byte[] certificate = null;
                X509Certificate2 x509Certificate2 = new X509Certificate2();
                certificate = Convert.FromBase64String(cert64);
                x509Certificate2 = new X509Certificate2(certificate, certificatePass);
                response.Success = true;
                response.Object = x509Certificate2;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public static SignatureParameters SignatureParameters(bool isAnnulment = false)
        {
            return (!isAnnulment) ? SignCore.SATSignatureParameters.SignatureParameters() : SignCore.SATSignatureParameters.SignatureParameters("dte", "dte:GTAnulacionDocumento", "DatosAnulacion");
        }
    }
}
