using AddOns;
using GTDocumento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using APIFel.Helper;

namespace APIFel.Model
{
    public class General
    {
        public string version { get; set; }
        public string claseDocumento { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroInterno { get; set; }
        public string serieInterna { get; set; }
        public string exp { get; set; }
        public string fechaDocumento { get; set; }
        public string codigoMoneda { get; set; }
        public string numeroDeAcceso { get; set; }
        public string granTotal { get; set; }

        public General()
        {
            this.version = string.Empty;
            this.claseDocumento = string.Empty;
            this.tipoDocumento = string.Empty;
            this.numeroInterno = string.Empty;
            this.serieInterna = string.Empty;
            this.exp = string.Empty;
            this.fechaDocumento = string.Empty;
            this.codigoMoneda = string.Empty;
            this.numeroDeAcceso = string.Empty;
        }
    }
    public class Emisor
    {
        public string nit { get; set; }
        public string RazonSocial { get; set; }
        public string codigoEstablecimiento { get; set; }
        public string nombreComercial { get; set; }
        public string correo { get; set; }
        public string afiliciacionIVA { get; set; }
        public string direccion { get; set; }
        public string codigoPostal { get; set; }
        public string municipio { get; set; }
        public string departamento { get; set; }
        public string pais { get; set; }


        public Emisor()
        {
            this.nit = string.Empty;
            this.RazonSocial = string.Empty;
            this.codigoEstablecimiento = string.Empty;
            this.nombreComercial = string.Empty;
            this.correo = string.Empty;
            this.afiliciacionIVA = string.Empty;
            this.direccion = string.Empty;
            this.codigoPostal = string.Empty;
            this.municipio = string.Empty;
            this.departamento = string.Empty;
            this.pais = string.Empty;
        }
    }
    public class Receptor
    {
        public string idReceptor { get; set; }
        public string tipoEspecial { get; set; }
        public string razonSocialCliente { get; set; }
        public string correoCliente { get; set; }
        public string direccionCliente { get; set; }
        public string codigoPostalCliente { get; set; }
        public string municipioCliente { get; set; }
        public string departamentoCliente { get; set; }
        public string paisCliente { get; set; }

        public Receptor()
        {
            this.idReceptor = string.Empty;
            this.tipoEspecial = string.Empty;
            this.razonSocialCliente = string.Empty;
            this.correoCliente = string.Empty;
            this.direccionCliente = string.Empty;
            this.codigoPostalCliente = string.Empty;
            this.municipioCliente = string.Empty;
            this.departamentoCliente = string.Empty;
            this.paisCliente = string.Empty;
        }
    }
    public class Impuestos
    {
        public string nombrecorto { get; set; }
        public string codigoUnidadGravable { get; set; }
        public string montoGravable { get; set; }
        public string cantidadUnidadGravable { get; set; }
        public string montoImpuesto { get; set; }

        public Impuestos()
        {
            this.nombrecorto = string.Empty;
            this.codigoUnidadGravable = string.Empty;
            this.montoGravable = string.Empty;
            this.cantidadUnidadGravable = string.Empty;
            this.montoImpuesto = string.Empty;
        }
    }
    public class Detalle
    {
        public string numeroLinea { get; set; }
        public string bienOServicio { get; set; }
        public string cantidad { get; set; }
        public string unidadDeMedida { get; set; }
        public string precioUnitario { get; set; }
        public string precioXCantidad { get; set; }
        public string descuento { get; set; }
        public List<Impuestos> impuestos { get; set; } // 2 impuestos si mucho
        public string total { get; set; }
        public string descripcion { get; set; }
        public string codigoItem { get; set; }

        public Detalle()
        {
            this.numeroLinea = string.Empty;
            this.bienOServicio = string.Empty;
            this.cantidad = string.Empty;
            this.unidadDeMedida = string.Empty;
            this.precioUnitario = string.Empty;
            this.precioXCantidad = string.Empty;
            this.descuento = string.Empty;
            this.impuestos = new List<Impuestos>(); ;
            this.total = string.Empty;
            this.descripcion = string.Empty;
            this.codigoItem = string.Empty;
        }
    }
    public class ComplementoCambiaria
    {
        public string numeroAbono { get; set; }
        public string fechaVencimiento { get; set; }
        public string montoAbono { get; set; }

        public ComplementoCambiaria()
        {
            this.numeroAbono = string.Empty;
            this.fechaVencimiento = string.Empty;
            this.montoAbono = string.Empty;
        }

    }
    public class ComplementoExportacion
    {
        public string nombreconsignatarioDestino { get; set; }
        public string direccionConsignatarioDestino { get; set; }
        public string codigoConsignatarioDestino { get; set; }
        public string nombreComprador { get; set; }
        public string direccionComprador { get; set; }
        public string otraReferencia { get; set; }
        public string incoterm { get; set; }
        public string nombreExportador { get; set; }
        public string codigoExportador { get; set; }
        public string codigoComprador { get; set; }

        public ComplementoExportacion()
        {
            this.nombreconsignatarioDestino = string.Empty;
            this.direccionConsignatarioDestino = string.Empty;
            this.codigoConsignatarioDestino = string.Empty;
            this.nombreComprador = string.Empty;
            this.direccionComprador = string.Empty;
            this.otraReferencia = string.Empty;
            this.incoterm = string.Empty;
            this.nombreExportador = string.Empty;
            this.codigoExportador = string.Empty;
            this.codigoComprador = string.Empty;
        }
    }
    public class ComplementoEspecial
    {
        public string retencionISR { get; set; }
        public string retencionIVA { get; set; }
        public string totalMenosRetencones { get; set; }

        public ComplementoEspecial()
        {
            this.retencionISR = string.Empty;
            this.retencionIVA = string.Empty;
            this.totalMenosRetencones = string.Empty;
        }

    }
    public class ComplementoNotas
    {
        public string regimenAntiguo { get; set; }
        public string numeroAutrizacionDcumento { get; set; }
        public string fechaEmisionDocumentoOrigen { get; set; }
        public string motivoAjuste { get; set; }
        public string serieDocumentoOrigen { get; set; }
        public string numeroDocumentoOrigen { get; set; }

        public ComplementoNotas()
        {
            this.regimenAntiguo = string.Empty;
            this.numeroAutrizacionDcumento = string.Empty;
            this.fechaEmisionDocumentoOrigen = string.Empty;
            this.motivoAjuste = string.Empty;
            this.serieDocumentoOrigen = string.Empty;
            this.numeroDocumentoOrigen = string.Empty;
        }
    }
    public class ImpuestosResumen
    {
        public string tipoFrases { get; set; }
        public string codigoFrases { get; set; }

        public ImpuestosResumen()
        {
            this.tipoFrases = string.Empty;
            this.codigoFrases = string.Empty;
        }
    }
    public class Frases
    {
        public string tipoFrases { get; set; }
        public string codigoFrases { get; set; }

        public Frases()
        {
            this.tipoFrases = string.Empty;
            this.codigoFrases = string.Empty;
        }
    }
    public class AddendaResumen
    {
        public string valor1 { get; set; }
        public string valor2 { get; set; }
        public string valor3 { get; set; }
        public string valor4 { get; set; }
        public string valor5 { get; set; }
        public string valor6 { get; set; }
        public string valor7 { get; set; }
        public string valor8 { get; set; }
        public string valor9 { get; set; }
        public string valor10 { get; set; }
        public string valor11 { get; set; }
        public string valor12 { get; set; }
        public string valor13 { get; set; }
        public string valor14 { get; set; }
        public string valor15 { get; set; }
        public string valor16 { get; set; }

        public AddendaResumen(string valor1, string valor2, string valor3, string valor4, string valor5, string valor6, string valor7, string valor8, string valor9, string valor10, string valor11, string valor12, string valor13, string valor14, string valor15, string valor16)
        {
            this.valor1 = valor1;
            this.valor2 = valor2;
            this.valor3 = valor3;
            this.valor4 = valor4;
            this.valor5 = valor5;
            this.valor6 = valor6;
            this.valor7 = valor7;
            this.valor8 = valor8;
            this.valor9 = valor9;
            this.valor10 = valor10;
            this.valor11 = valor11;
            this.valor12 = valor12;
            this.valor13 = valor13;
            this.valor14 = valor14;
            this.valor15 = valor15;
            this.valor16 = valor16;
        }

        public AddendaResumen()
        {
            this.valor1 = string.Empty;
            this.valor2 = string.Empty;
            this.valor3 = string.Empty;
            this.valor4 = string.Empty;
            this.valor5 = string.Empty;
            this.valor6 = string.Empty;
            this.valor7 = string.Empty;
            this.valor8 = string.Empty;
            this.valor9 = string.Empty;
            this.valor10 = string.Empty;
            this.valor11 = string.Empty;
            this.valor12 = string.Empty;
            this.valor13 = string.Empty;
            this.valor14 = string.Empty;
            this.valor15 = string.Empty;
            this.valor16 = string.Empty;
        }
    }
    public class AddendaItem
    {
        public string lineaReferencia { get; set; }
        public string valor1 { get; set; }
        public string valor2 { get; set; }
        public string valor3 { get; set; }
        public string valor4 { get; set; }
        public string valor5 { get; set; }
        public string valor6 { get; set; }
        public string valor7 { get; set; }
        public string valor8 { get; set; }
        public string valor9 { get; set; }
        public string valor10 { get; set; }
        public string valor11 { get; set; }
        public string valor12 { get; set; }
        public string valor13 { get; set; }
        public string valor14 { get; set; }
        public string valor15 { get; set; }
        public string valor16 { get; set; }
        public string valor17 { get; set; }
        public string valor18 { get; set; }
        public string valor19 { get; set; }
        public string valor20 { get; set; }

        public AddendaItem(string lineaReferencia, string valor1, string valor2, string valor3, string valor4, string valor5, string valor6, string valor7, string valor8, string valor9, string valor10, string valor11, string valor12, string valor13, string valor14, string valor15, string valor16, string valor17, string valor18, string valor19, string valor20)
        {
            this.lineaReferencia = lineaReferencia;
            this.valor1 = valor1;
            this.valor2 = valor2;
            this.valor3 = valor3;
            this.valor4 = valor4;
            this.valor5 = valor5;
            this.valor6 = valor6;
            this.valor7 = valor7;
            this.valor8 = valor8;
            this.valor9 = valor9;
            this.valor10 = valor10;
            this.valor11 = valor11;
            this.valor12 = valor12;
            this.valor13 = valor13;
            this.valor14 = valor14;
            this.valor15 = valor15;
            this.valor16 = valor16;
            this.valor17 = valor17;
            this.valor18 = valor18;
            this.valor19 = valor19;
            this.valor20 = valor20;
        }

        public AddendaItem()
        {
            this.lineaReferencia = lineaReferencia;
            this.valor1 = string.Empty;
            this.valor2 = string.Empty;
            this.valor3 = string.Empty;
            this.valor4 = string.Empty;
            this.valor5 = string.Empty;
            this.valor6 = string.Empty;
            this.valor7 = string.Empty;
            this.valor8 = string.Empty;
            this.valor9 = string.Empty;
            this.valor10 = string.Empty;
            this.valor11 = string.Empty;
            this.valor12 = string.Empty;
            this.valor13 = string.Empty;
            this.valor14 = string.Empty;
            this.valor15 = string.Empty;
            this.valor16 = string.Empty;
            this.valor17 = string.Empty;
            this.valor18 = string.Empty;
            this.valor19 = string.Empty;
            this.valor20 = string.Empty;
        }
    }
    public class Documento
    {
        public General general { get; set; }
        public Emisor emisor { get; set; }
        public Receptor receptor { get; set; }
        public List<Detalle> detalles { get; set; }
        public ComplementoCambiaria complementoCambiaria { get; set; }
        public ComplementoExportacion complementoExportacion { get; set; }
        public ComplementoEspecial complementoEspecial { get; set; }
        public ComplementoNotas complementoNotas { get; set; }
        public ImpuestosResumen impuestos { get; set; }
        public List<Frases> frases { get; set; }
        public AddendaResumen addendaResumen { get; set; }
        public List<AddendaItem> addendaItems { get; set; }

        public  Documento()
        {
            this.general = new General();
            this.emisor = new Emisor();
            this.receptor = new Receptor();
            this.detalles = new List<Detalle>();
            this.complementoCambiaria = new ComplementoCambiaria();
            this.complementoExportacion = new ComplementoExportacion();
            this.complementoEspecial = new ComplementoEspecial();
            this.complementoNotas = new ComplementoNotas();
            this.frases = new List<Frases>();
            this.addendaResumen = new AddendaResumen();
            this.addendaItems = new List<AddendaItem>();
        }
        
    }
}