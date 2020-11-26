using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace APIFel.Helper
{
    public static class XMLHelper
    {
        #region Specs
        /// <summary>
        /// Serializa un objeto enviado especificando tipo y elemento, devuelve el XmlElement del objeto serializado
        /// </summary>
        /// <param name="type">Tipo a serializar</param>
        /// <param name="element">Objeto a serializar</param>
        /// <returns>XmlElement (DocumentElement)</returns>
        #endregion
        public static XmlElement Serialize(Type type, object element)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            XmlDocument document = new XmlDocument();
            string result = string.Empty;

            using (StringWriter w = new UTF8StringWriter(Encoding.UTF8))
            {
                serializer.Serialize(w, element, Namespaces(type));
                result = w.ToString();
            }

            document.LoadXml(result.NormalizeSpecialCharacters());
            return document.DocumentElement;
        }

        #region Specs
        /// <summary>
        /// Serializa un objeto enviado especificando tipo y elemento, devuelve la cadena del objeto serializado
        /// </summary>
        /// <param name="type">Tipo a serializar</param>
        /// <param name="element">Objeto a serializar</param>
        /// <returns>Cadena con objeto serializado</returns>
        #endregion
        public static string SerializeToString(Type type, object element)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            string result = string.Empty;

            using (StringWriter w = new UTF8StringWriter(Encoding.UTF8))
            {
                serializer.Serialize(w, element, Namespaces(type));
                result = w.ToString();
            }

            return result.NormalizeSpecialCharacters();
        }

        #region Specs
        /// <summary>
        /// Serializa un objeto enviado especificando tipo y elemento, devuelve el XmlDocument del objeto serializado
        /// </summary>
        /// <param name="type">Tipo a serializar</param>
        /// <param name="element">Objeto a serializar</param>
        /// <returns>XmlDocument</returns>
        #endregion
        public static XmlDocument SerializeToXmlDocument(Type type, object element)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            XmlDocument document = new XmlDocument() { PreserveWhitespace = true };
            string result = string.Empty;

            using (StringWriter w = new UTF8StringWriter(Encoding.UTF8))
            {
                serializer.Serialize(w, element, Namespaces(type));
                result = w.ToString();
            }

            document.LoadXml(result.NormalizeSpecialCharacters());
            return document;
        }

        #region Specs
        /// <summary>
        /// Agrega los espacios de nombres derivado de un tipo enviado, este es una ayuda para no especificar los nombres de los xsd de SAT
        /// </summary>
        /// <param name="type">Tipo de objeto a serializar</param>
        /// <returns>Colección de espacios de nombre a incrustar en el xml a serializar</returns>
        #endregion
        private static XmlSerializerNamespaces Namespaces(Type type)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            switch (type.Name)
            {
                case nameof(GTDocumento.GTDocumento):
                    //case nameof(GTDocumento.Addendum.AdendaDetail):
                    namespaces.Add("dte", "http://www.sat.gob.gt/dte/fel/0.2.0"); // cambio de version a partir de Abril
                    break;
                case nameof(GTAnulacionDocumento.GTAnulacionDocumento):
                    namespaces.Add("dte", "http://www.sat.gob.gt/dte/fel/0.1.0");
                    break;
                case nameof(AddOns.AbonosFacturaCambiaria):
                    namespaces.Add("cab", "http://www.sat.gob.gt/dte/fel/CompCambiaria/0.1.0"); // cfc antes
                    break;
                case nameof(AddOns.Exportacion):
                    namespaces.Add("cex", "http://www.sat.gob.gt/face2/ComplementoExportaciones/0.1.0");
                    break;
                case nameof(AddOns.RetencionesFacturaEspecial):
                    namespaces.Add("cfe", "http://www.sat.gob.gt/face2/ComplementoFacturaEspecial/0.1.0");
                    break;
                case nameof(AddOns.ReferenciasNota):
                    namespaces.Add("cno", "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0");
                    break;
                case nameof(APIFel.Model.AdendaDetail):
                    break;
                case null:
                    break;
                default:
                    //throw new ArgumentNullException("Esquema no relacionado a documentos SAT.");
                    break;
            }

            return namespaces;
        }

        public static object Deserialize(Type type, Stream element)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            var result = serializer.Deserialize(element);

            return result;
        }

        public static object Deserialize(Type type, string element)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            var result = serializer.Deserialize(new StringReader(element));
            return result;
        }
    }
}