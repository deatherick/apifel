using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirmaXadesNet.Crypto;
using FirmaXadesNet.Signature.Parameters;

namespace SignCore
{
    public static class SATSignatureParameters
    {
        public static SignatureParameters SignatureParameters(string _nameSapce = "dte", string _xPathExpression = "dte:GTDocumento", string _elementIdToSign = "DatosEmision")
        {
            SignatureXPathExpression signatureDestination = new SignatureXPathExpression();
            if (_xPathExpression == "dte:GTAnulacionDocumento")
            {
                signatureDestination.Namespaces.Add(_nameSapce, "http://www.sat.gob.gt/dte/fel/0.1.0");
            }
            else
            {
                //signatureDestination.Namespaces.Add(_nameSapce, "http://www.sat.gob.gt/dte/fel/0.1.0");
                signatureDestination.Namespaces.Add(_nameSapce, "http://www.sat.gob.gt/dte/fel/0.2.0"); // nueva version de XML
            }
            signatureDestination.XPathExpression = _xPathExpression;

            SignatureParameters parameters = new SignatureParameters()  //Signature parameters
            {
                SignatureMethod = SignatureMethod.RSAwithSHA256,
                SigningDate = DateTime.Now,
                SignaturePackaging = SignaturePackaging.INTERNALLY_DETACHED,
                InputMimeType = "text/xml",
                ElementIdToSign = _elementIdToSign,
                SignatureDestination = signatureDestination
            };

            return parameters;
        }
    }
}
