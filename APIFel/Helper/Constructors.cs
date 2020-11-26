using AddOns;
using GTDocumento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIFel.Helper;

namespace GTDocumento
{
    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionItemCantidad
    /// con sus valores correspondientes
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionItemCantidad
    {
        public GTDocumentoSATDTEDatosEmisionItemCantidad() { }

        public GTDocumentoSATDTEDatosEmisionItemCantidad(decimal value)
        {
            this.Value = value;
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionItemImpuesto
    /// con sus valores correspondientes
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionItemImpuesto
    {
        public GTDocumentoSATDTEDatosEmisionItemImpuesto() { }

        public GTDocumentoSATDTEDatosEmisionItemImpuesto(string nombreCorto, string codigoUnidadGravable, decimal montoGravable, decimal cantidadUnidadesGravables, decimal montoImpuesto)
        {
            this.NombreCorto = (GTDocumentoSATDTEDatosEmisionItemImpuestoNombreCorto)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionItemImpuestoNombreCorto), nombreCorto);
            this.CodigoUnidadGravable = codigoUnidadGravable;
            this.MontoGravable = montoGravable;
            this.MontoGravableSpecified = true;
            this.CantidadUnidadesGravables = cantidadUnidadesGravables;
            this.CantidadUnidadesGravablesSpecified = (this.CantidadUnidadesGravables != 0);
            this.MontoImpuesto = new GTDocumentoSATDTEDatosEmisionItemImpuestoMontoImpuesto() { Value = montoImpuesto };
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionItemImpuestoMontoImpuesto
    /// con sus valor
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionItemImpuestoMontoImpuesto
    {
        public GTDocumentoSATDTEDatosEmisionItemImpuestoMontoImpuesto() { }

        public GTDocumentoSATDTEDatosEmisionItemImpuestoMontoImpuesto(decimal value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionDatosGenerales
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionDatosGenerales
    {
        public GTDocumentoSATDTEDatosEmisionDatosGenerales() { }

        public GTDocumentoSATDTEDatosEmisionDatosGenerales(string tipoMoneda, DateTime fechaHoraEmision, string tipo)
        {
            this.CodigoMoneda = (tipoMoneda)Enum.Parse(typeof(tipoMoneda), tipoMoneda);
            this.FechaHoraEmision = fechaHoraEmision;
            this.Tipo = (GTDocumentoSATDTEDatosEmisionDatosGeneralesTipo)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionDatosGeneralesTipo), tipo);
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionEmisor
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionEmisor
    {
        public GTDocumentoSATDTEDatosEmisionEmisor() { }

        /// <summary>
        /// constructor que recibe DireccionEmisor como objeto
        /// </summary>
        /// <param name="afiliacionIVA"></param>
        /// <param name="codigoEstablecimiento"></param>
        /// <param name="NITEmisor"></param>
        /// <param name="nombreComercial"></param>
        /// <param name="nombreEmisor"></param>
        /// <param name="direccionEmisor"></param>
        public GTDocumentoSATDTEDatosEmisionEmisor(string afiliacionIVA, string codigoEstablecimiento, string NITEmisor, string nombreComercial, string nombreEmisor, tipoDireccion direccionEmisor)
        {
            this.AfiliacionIVA = (GTDocumentoSATDTEDatosEmisionEmisorAfiliacionIVA)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionEmisorAfiliacionIVA), afiliacionIVA);
            this.CodigoEstablecimiento = codigoEstablecimiento;
            this.NITEmisor = NITEmisor;
            this.NombreComercial = nombreComercial;
            this.NombreEmisor = nombreEmisor;
            this.DireccionEmisor = direccionEmisor;

        }

        /// <summary>
        /// constructor que recibe como parámetros los valores de los atributos de DireccionEmisor
        /// y construye el objeto a partir de los mismos
        /// </summary>
        /// <param name="afiliacionIVA"></param>
        /// <param name="codigoEstablecimiento"></param>
        /// <param name="NITEmisor"></param>
        /// <param name="nombreComercial"></param>
        /// <param name="nombreEmisor"></param>
        /// <param name="codigoPostal"></param>
        /// <param name="departamento"></param>
        /// <param name="municipio"></param>
        /// <param name="pais"></param>
        /// <param name="direccion"></param>
        public GTDocumentoSATDTEDatosEmisionEmisor(string afiliacionIVA, string codigoEstablecimiento, string NITEmisor, string nombreComercial, string nombreEmisor, string codigoPostal, string departamento, string municipio, string pais, string direccion)
        {
            this.AfiliacionIVA = (GTDocumentoSATDTEDatosEmisionEmisorAfiliacionIVA)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionEmisorAfiliacionIVA), afiliacionIVA);
            this.CodigoEstablecimiento = codigoEstablecimiento;
            this.NITEmisor = NITEmisor;
            this.NombreComercial = nombreComercial;
            this.NombreEmisor = nombreEmisor;
            this.DireccionEmisor = new tipoDireccion()
            {
                CodigoPostal = codigoPostal,
                Departamento = departamento,
                Municipio = municipio,
                Pais = (tipoDireccionPais)Enum.Parse(typeof(tipoDireccionPais), pais),
                Direccion = direccion
            };
        }
    }

    /// <summary>
    /// constructores para instanciar objeto tipoDireccion
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class tipoDireccion
    {
        public tipoDireccion() { }

        public tipoDireccion(string codigoPostal, string departamento, string municipio, string pais, string direccion)
        {
            this.CodigoPostal = codigoPostal;
            this.Departamento = departamento;
            this.Municipio = municipio;
            this.Pais = (tipoDireccionPais)Enum.Parse(typeof(tipoDireccionPais), pais);
            this.Direccion = direccion;
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionReceptor
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionReceptor
    {
        public GTDocumentoSATDTEDatosEmisionReceptor() { }

        /// <summary>
        /// constructor que recibe parametro DireccionReceptor como objeto
        /// </summary>
        /// <param name="correoReceptor"></param>
        /// <param name="IDReceptor"></param>
        /// <param name="nombreReceptor"></param>
        /// <param name="direccionReceptor"></param>
        public GTDocumentoSATDTEDatosEmisionReceptor(string correoReceptor, string IDReceptor, string nombreReceptor, tipoDireccion direccionReceptor)
        {
            this.CorreoReceptor = correoReceptor;
            this.IDReceptor = IDReceptor;
            this.NombreReceptor = nombreReceptor;
            this.DireccionReceptor = direccionReceptor;
        }

        /// <summary>
        /// constructor que recibe como parámetros los valores de los atributos de tipoDireccion
        /// y construye el objeto a partir de los mismos
        /// </summary>
        /// <param name="correoReceptor"></param>
        /// <param name="IDReceptor"></param>
        /// <param name="nombreReceptor"></param>
        /// <param name="direccionReceptor_codigoPostal"></param>
        /// <param name="direccionReceptor_departamento"></param>
        /// <param name="direccionReceptor_departamento"></param>
        /// <param name="direccionReceptor_direccion"></param>
        /// <param name="direccionReceptor_municipio"></param>
        /// <param name="direccionReceptor_pais"></param>
        public GTDocumentoSATDTEDatosEmisionReceptor(string correoReceptor, string IDReceptor, string nombreReceptor, string direccionReceptor_codigoPostal, string direccionReceptor_departamento, string direccionReceptor_direccion, string direccionReceptor_municipio, string direccionReceptor_pais)
        {
            this.CorreoReceptor = correoReceptor;
            this.IDReceptor = IDReceptor;
            this.NombreReceptor = nombreReceptor;
            this.DireccionReceptor = new tipoDireccion()
            {
                CodigoPostal = direccionReceptor_codigoPostal,
                Departamento = direccionReceptor_departamento,
                Direccion = direccionReceptor_direccion,
                Municipio = direccionReceptor_municipio,
                Pais = (tipoDireccionPais)Enum.Parse(typeof(tipoDireccionPais), direccionReceptor_pais)
            };
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionFrase
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionFrase
    {
        public GTDocumentoSATDTEDatosEmisionFrase() { }

        public GTDocumentoSATDTEDatosEmisionFrase(int codigoEscenario, string tipoFrase)
        {
            this.CodigoEscenario = codigoEscenario;
            this.TipoFrase = tipoFrase;
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionItem
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionItem
    {
        public GTDocumentoSATDTEDatosEmisionItem() { }

        /// <summary>
        /// constructor que recibe parametro GTDocumentoSATDTEDatosEmisionItemImpuesto[] como arreglo de objetos
        /// </summary>
        /// <param name="bienOServicio"></param>
        /// <param name="numeroLinea"></param>
        /// <param name="unidadMedida"></param>
        /// <param name="descripcion"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="precio"></param>
        /// <param name="descuento"></param>
        /// <param name="cantidad"></param>
        /// <param name="total"></param>
        /// <param name="impuestos"></param>
        public GTDocumentoSATDTEDatosEmisionItem(string bienOServicio, string numeroLinea, string unidadMedida, string descripcion, decimal precioUnitario, decimal precio, decimal descuento, decimal cantidad, decimal total, GTDocumentoSATDTEDatosEmisionItemImpuesto[] impuestos)
        {
            this.BienOServicio = (GTDocumentoSATDTEDatosEmisionItemBienOServicio)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionItemBienOServicio), bienOServicio);
            this.NumeroLinea = numeroLinea;
            this.UnidadMedida = unidadMedida;
            this.Descripcion = descripcion;
            this.PrecioUnitario = precioUnitario;
            this.Precio = precio;
            this.Descuento = descuento;
            this.DescuentoSpecified = true;
            this.Cantidad = new GTDocumentoSATDTEDatosEmisionItemCantidad(cantidad);
            this.Total = total;
            this.Impuestos = impuestos;
        }

        /// <summary>
        /// constructor que recibe como parámetros los valores de los atributos de GTDocumentoSATDTEDatosEmisionItemImpuesto
        /// y construye el objeto a partir de los mismos
        /// </summary>
        /// <param name="bienOServicio"></param>
        /// <param name="numeroLinea"></param>
        /// <param name="unidadMedida"></param>
        /// <param name="descripcion"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="precio"></param>
        /// <param name="descuento"></param>
        /// <param name="cantidad"></param>
        /// <param name="total"></param>
        /// <param name="impuesto_nombreCorto"></param>
        /// <param name="impuesto_codigoUnidadGravable"></param>
        /// <param name="impuesto_montoGrabable"></param>
        /// <param name="impuesto_montoGravableSpecified"></param>
        /// <param name="impuesto_montoImpuesto"></param>
        public GTDocumentoSATDTEDatosEmisionItem(string bienOServicio, string numeroLinea, string unidadMedida, string descripcion, decimal precioUnitario, decimal precio, decimal descuento, decimal cantidad, decimal total, string impuesto_nombreCorto, string impuesto_codigoUnidadGravable, decimal impuesto_montoGrabable, bool impuesto_montoGravableSpecified, decimal impuesto_montoImpuesto)
        {
            this.BienOServicio = (GTDocumentoSATDTEDatosEmisionItemBienOServicio)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionItemBienOServicio), bienOServicio);
            this.NumeroLinea = numeroLinea;
            this.UnidadMedida = unidadMedida;
            this.Descripcion = descripcion;
            this.PrecioUnitario = precioUnitario;
            this.Precio = precio;
            this.Descuento = descuento;
            this.DescuentoSpecified = true;
            this.Cantidad = new GTDocumentoSATDTEDatosEmisionItemCantidad(cantidad);
            this.Total = total;
            this.Impuestos = new GTDocumentoSATDTEDatosEmisionItemImpuesto[1]
            {
                new GTDocumentoSATDTEDatosEmisionItemImpuesto()
                {
                    NombreCorto = (GTDocumentoSATDTEDatosEmisionItemImpuestoNombreCorto)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionItemImpuestoNombreCorto), impuesto_nombreCorto),
                    CodigoUnidadGravable = impuesto_codigoUnidadGravable,
                    MontoGravable = impuesto_montoGrabable,
                    MontoGravableSpecified = impuesto_montoGravableSpecified,
                    MontoImpuesto = new GTDocumentoSATDTEDatosEmisionItemImpuestoMontoImpuesto()
                    {
                        Value = impuesto_montoImpuesto
                    }
                }
            };
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto
    {
        public GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto() { }

        public GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto(string nombreCorto, decimal totalMontoImpuesto)
        {
            this.NombreCorto = (GTDocumentoSATDTEDatosEmisionItemImpuestoNombreCorto)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionItemImpuestoNombreCorto), nombreCorto);
            this.TotalMontoImpuesto = totalMontoImpuesto;
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionTotales
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum 
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionTotales
    {
        public GTDocumentoSATDTEDatosEmisionTotales() { }

        /// <summary>
        /// constructor que recibe parámetro impuestos 
        /// como objeto de tipo GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto[]
        /// </summary>
        /// <param name="granTotal"></param>
        /// <param name="impuestos"></param>
        public GTDocumentoSATDTEDatosEmisionTotales(decimal granTotal, GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto[] impuestos)
        {
            this.GranTotal = granTotal;
            this.TotalImpuestos = impuestos;
        }

        /// <summary>
        /// constructor que recibe como parámetros los valores de los atributos de GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto
        /// y construye el objeto a partir de los mismos
        /// </summary>
        /// <param name="granTotal"></param>
        /// <param name="totalImpuestos_nombreCorto"></param>
        /// <param name="totalImpuestos_totalMontoImpuesto"></param>
        public GTDocumentoSATDTEDatosEmisionTotales(decimal granTotal, string totalImpuestos_nombreCorto, decimal totalImpuestos_totalMontoImpuesto)
        {
            this.GranTotal = granTotal;
            this.TotalImpuestos = new GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto[1]
            {
                new GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto()
                {
                    NombreCorto = (GTDocumentoSATDTEDatosEmisionItemImpuestoNombreCorto)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionItemImpuestoNombreCorto), totalImpuestos_nombreCorto),
                    TotalMontoImpuesto = totalImpuestos_totalMontoImpuesto
                }
            };
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionComplementosComplemento
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionComplementosComplemento
    {
        public GTDocumentoSATDTEDatosEmisionComplementosComplemento() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreComplemento"></param>
        /// <param name="IDComplemento"></param>
        /// <param name="URIComplemento"></param>
        /// <param name="type"></param>
        /// <param name="complemento"></param>
        public GTDocumentoSATDTEDatosEmisionComplementosComplemento(string nombreComplemento, string IDComplemento, string URIComplemento, Type type, object complemento)
        {
            this.NombreComplemento = nombreComplemento;
            this.IDComplemento = IDComplemento;
            this.URIComplemento = URIComplemento;
            this.Any = XMLHelper.Serialize(type, complemento);
        }

        /// <summary>
        /// constructor que recibe parámetro abono
        /// como objeto de tipo AbonosFacturaCambiaria
        /// </summary>
        /// <param name="nombreComplemento"></param>
        /// <param name="IDComplemento"></param>
        /// <param name="URIComplemento"></param>
        /// <param name="abono"></param>
        public GTDocumentoSATDTEDatosEmisionComplementosComplemento(string nombreComplemento, string IDComplemento, string URIComplemento, AbonosFacturaCambiaria abono)
        {
            this.NombreComplemento = nombreComplemento;
            this.IDComplemento = IDComplemento;
            this.URIComplemento = URIComplemento;
            this.Any = XMLHelper.Serialize(typeof(AbonosFacturaCambiaria), abono);
        }

        /// <summary>
        /// constructor que recibe como parámetros los valores de los atributos de AbonosFacturaCambiariaAbono
        /// y construye el objeto a partir de los mismos
        /// </summary>
        /// <param name="nombreComplemento"></param>
        /// <param name="IDComplemento"></param>
        /// <param name="URIComplemento"></param>
        /// <param name="abono_fechaVencimiento"></param>
        /// <param name="abono_montoAbono"></param>
        /// <param name="abono_numeroAbono"></param>
        public GTDocumentoSATDTEDatosEmisionComplementosComplemento(string nombreComplemento, string IDComplemento, string URIComplemento, DateTime abono_fechaVencimiento, float abono_montoAbono, int abono_numeroAbono)
        {
            this.NombreComplemento = nombreComplemento;
            this.IDComplemento = IDComplemento;
            this.URIComplemento = URIComplemento;
            this.Any = XMLHelper.Serialize(typeof(AbonosFacturaCambiaria),
                new AbonosFacturaCambiaria()
                {
                    Abono = new AbonosFacturaCambiariaAbono[1]
                    {
                        new AbonosFacturaCambiariaAbono()
                        {
                            FechaVencimiento = abono_fechaVencimiento,
                            MontoAbono = abono_montoAbono,
                            NumeroAbono = abono_numeroAbono
                        }
                    }
                }
            );
        }

    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmisionComplementos
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionComplementos
    {
        public GTDocumentoSATDTEDatosEmisionComplementos() { }

        /// <summary>
        /// constructor que recibe parámetro complemento
        /// como objeto de tipo GTDocumentoSATDTEDatosEmisionComplementosComplemento[]
        /// </summary>
        /// <param name="complemento"></param>
        public GTDocumentoSATDTEDatosEmisionComplementos(GTDocumentoSATDTEDatosEmisionComplementosComplemento[] complemento)
        {
            Complemento = complemento;
        }

        /// <summary>
        /// constructor que recibe como parámetros los valores de los atributos de AbonosFacturaCambiariaAbono
        /// y construye el objeto a partir de los mismos
        /// </summary>
        /// <param name="nombreComplemento"></param>
        /// <param name="IDComplemento"></param>
        /// <param name="URIComplemento"></param>
        /// <param name="abono_fechaVencimiento"></param>
        /// <param name="abono_montoAbono"></param>
        /// <param name="abono_numeroAbono"></param>
        public GTDocumentoSATDTEDatosEmisionComplementos(string nombreComplemento, string IDComplemento, string URIComplemento, DateTime abono_fechaVencimiento, float abono_montoAbono, int abono_numeroAbono)
        {
            this.Complemento = new GTDocumentoSATDTEDatosEmisionComplementosComplemento[1] {
                new GTDocumentoSATDTEDatosEmisionComplementosComplemento()
                {
                    NombreComplemento = nombreComplemento,
                    IDComplemento = IDComplemento,
                    URIComplemento = URIComplemento,
                    Any = XMLHelper.Serialize(typeof(AbonosFacturaCambiaria),
                        new AbonosFacturaCambiaria()
                            {
                                Abono = new AbonosFacturaCambiariaAbono[1]
                                {
                                    new AbonosFacturaCambiariaAbono()
                                    {
                                        FechaVencimiento = abono_fechaVencimiento,
                                        MontoAbono = abono_montoAbono,
                                        NumeroAbono = abono_numeroAbono
                                    }
                                }
                            }
                        )
                }
            };
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTEDatosEmision
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmision
    {
        /// <summary>
        /// constructor que recibe los parámetros como objetos de su tipo correspondiente
        /// </summary>
        /// <param name="emisor"></param>
        /// <param name="receptor"></param>
        /// <param name="complementos"></param>
        /// <param name="datosGenerales"></param>
        /// <param name="items"></param>
        /// <param name="totales"></param>
        /// <param name="frases"></param>
        public GTDocumentoSATDTEDatosEmision(GTDocumentoSATDTEDatosEmisionEmisor emisor, GTDocumentoSATDTEDatosEmisionReceptor receptor, GTDocumentoSATDTEDatosEmisionComplementos complementos, GTDocumentoSATDTEDatosEmisionDatosGenerales datosGenerales, GTDocumentoSATDTEDatosEmisionItem[] items, GTDocumentoSATDTEDatosEmisionTotales totales, GTDocumentoSATDTEDatosEmisionFrase[] frases)
        {
            this.ID = "DatosEmision";

            this.Emisor = emisor;
            this.Receptor = receptor;
            this.Complementos = complementos;
            this.DatosGenerales = datosGenerales;
            this.Items = items;
            this.Totales = totales;
            this.Frases = frases;
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumentoSATDTE
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumentoSATDTE
    {
        public GTDocumentoSATDTE(GTDocumentoSATDTEDatosEmision datosEmision)
        {
            DatosEmision = datosEmision;
        }
    }

    /// <summary>
    /// constructores para instanciar objeto GTDocumento
    /// con sus valores correspondientes, recibiendo como string los atributos de tipo enum
    /// </summary>
    public partial class GTDocumento
    {
        // By CS_JZ
        public GTDocumento(GTDocumentoSATDTE dte)
        {
            this.Version = 0.4M;
            dte.ID = "DatosCertificados";
            this.SAT = new GTDocumentoSAT()
            {
                DTE = dte,
                ClaseDocumento = GTDocumentoSATClaseDocumento.dte
            };
        }

        public GTDocumento(GTDocumentoSATDTE dte, string claseDocumento)
        {
            this.Version = 0.4M;
            dte.ID = "DatosCertificados";
            this.SAT = new GTDocumentoSAT()
            {
                DTE = dte,
                ClaseDocumento = (GTDocumentoSATClaseDocumento)Enum.Parse(typeof(GTDocumentoSATClaseDocumento), claseDocumento)
            };
        }
    }
}

namespace GTAnulacionDocumento
{
    public partial class GTAnulacionDocumento
    {
        public GTAnulacionDocumento(string _numeroDocumentoAAnular, string _NITEmisor, string _IdReceptor, System.DateTime _fechaEmisionDocumentoAnular, System.DateTime _fechaHoraAnulacion, string _motivoAnulacion)
        {
            Version = 0.1M;

            SAT = new GTAnulacionDocumentoSAT()
            {
                AnulacionDTE = new GTAnulacionDocumentoSATAnulacionDTE()
                {
                    DatosGenerales = new GTAnulacionDocumentoSATAnulacionDTEDatosGenerales()
                    {
                        NumeroDocumentoAAnular = _numeroDocumentoAAnular,
                        NITEmisor = _NITEmisor,
                        IDReceptor = _IdReceptor,
                        FechaEmisionDocumentoAnular = _fechaEmisionDocumentoAnular,
                        FechaHoraAnulacion = _fechaHoraAnulacion,
                        MotivoAnulacion = _motivoAnulacion
                    }
                }
            };
        }
    }
}