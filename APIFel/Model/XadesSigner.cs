using FirmaXadesNet;
using FirmaXadesNet.Crypto;
using FirmaXadesNet.Signature.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml;

namespace SignCore
{

    /// <summary>
    /// Class to sign the xml with xades algorithm
    /// </summary>
    public class XadesSigner
    {
        /// <summary>
        /// Details the parameters to sign the document (Method, date, Packaging, MimeType, ElementIdToSign, Destination)
        /// </summary>
        public SignatureParameters SignatureParameters { get; set; }

        /// <summary>
        /// Document to sign
        /// </summary>
        private XmlDocument XmlDocument { get; set; }

        /// <summary>
        /// P12 certificate to sign the xml
        /// </summary>
        private X509Certificate2 Certificate { get; set; }

        public XadesSigner()
        {
            this.XmlDocument = null;
            this.Certificate = null;
            this.SignatureParameters = null;
        }

        public XadesSigner(XmlDocument xmlDocument, X509Certificate2 certificate)
        {
            this.XmlDocument = xmlDocument;
            this.Certificate = certificate;
        }

        public XadesSigner(XmlDocument xmlDocument, X509Certificate2 certificate, SignatureParameters signatureParameters)
        {
            this.XmlDocument = xmlDocument;
            this.Certificate = certificate;
            this.SignatureParameters = signatureParameters;
        }

        public string Sign()
        {
            XadesService xadesService = new XadesService();
            string result = null;

            using (this.SignatureParameters.Signer = new Signer(this.Certificate))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    MemoryStream signedXml = new MemoryStream();

                    XmlDocument.Save(stream); //Load the document to stream
                    //Reset stream
                    stream.Position = 0;
                    //Sign document
                    var signedDocument = xadesService.Sign(stream, this.SignatureParameters);
                    signedDocument.Save(signedXml); //Save the signed xml to stream
                    //Reset stream
                    signedXml.Position = 0;

                    var reader = new StreamReader(signedXml);
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }
}
