using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using AddOns;
using APIFel.Helper;
using APIFel.Model;
using GTDocumento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIFel.Controllers
{
    [ApiController]
    [Route("ApiFel")]
    public class PingController : ControllerBase, IPingService
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Ping(string msg)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("Login")]
        public Login Login()
        {
            Login login = new Login();
            return login;
        }
        [HttpGet("GeneraXML")]
        public Response<string> GeneraXML(Documento documento)
        {
            Response<string> response = new Response<string>();
            string result = String.Empty;
            try
            {
                GTDocumentoSAT GTDocumentoSAT = new GTDocumentoSAT() { ClaseDocumento = GTDocumentoSATClaseDocumento.dte };
                GTDocumentoSATDTEDatosEmision GTDocumentoSATDTEDatosEmision = new GTDocumentoSATDTEDatosEmision() { ID = "DatosEmision" };
                GTDocumentoSATDTEDatosEmisionDatosGenerales datosGenerales = null;
                // datos generales
                if (documento.general.exp == "Exp")
                {
                    datosGenerales = new GTDocumentoSATDTEDatosEmisionDatosGenerales()
                    {
                        CodigoMoneda = (tipoMoneda)Enum.Parse(typeof(tipoMoneda), documento.general.codigoMoneda),
                        // FechaHoraEmision = DateTime.Now.Date,
                        FechaHoraEmision = Convert.ToDateTime(documento.general.fechaDocumento).Date,
                        Exp = GTDocumentoSATDTEDatosEmisionDatosGeneralesExp.SI,
                        ExpSpecified = true,
                        Tipo = (GTDocumentoSATDTEDatosEmisionDatosGeneralesTipo)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionDatosGeneralesTipo), documento.general.tipoDocumento)
                    };
                }
                else
                {
                    datosGenerales = new GTDocumentoSATDTEDatosEmisionDatosGenerales()
                    {
                        CodigoMoneda = (tipoMoneda)Enum.Parse(typeof(tipoMoneda), documento.general.codigoMoneda),
                        // FechaHoraEmision = DateTime.Now.Date,
                        FechaHoraEmision = Convert.ToDateTime(documento.general.fechaDocumento).Date,
                        Tipo = (GTDocumentoSATDTEDatosEmisionDatosGeneralesTipo)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionDatosGeneralesTipo), documento.general.tipoDocumento)
                    };
                }


                // emisor
                GTDocumentoSATDTEDatosEmisionEmisor emisor = new GTDocumentoSATDTEDatosEmisionEmisor()
                {
                    AfiliacionIVA = GTDocumentoSATDTEDatosEmisionEmisorAfiliacionIVA.GEN,
                    CodigoEstablecimiento = documento.emisor.codigoEstablecimiento,
                    NITEmisor = documento.emisor.nit,
                    NombreComercial = documento.emisor.RazonSocial,
                    NombreEmisor = documento.emisor.RazonSocial,
                    DireccionEmisor = new tipoDireccion()
                    {
                        CodigoPostal = documento.emisor.codigoPostal,
                        Departamento = documento.emisor.departamento,
                        Municipio = documento.emisor.municipio,
                        Pais = tipoDireccionPais.GT,
                        Direccion = documento.emisor.direccion
                    }
                };

                // receptor
                GTDocumentoSATDTEDatosEmisionReceptor receptor = new GTDocumentoSATDTEDatosEmisionReceptor()
                {
                    CorreoReceptor = documento.receptor.correoCliente,
                    IDReceptor = documento.receptor.idReceptor,
                    NombreReceptor = documento.receptor.razonSocialCliente,
                    DireccionReceptor = new tipoDireccion()
                    {
                        CodigoPostal = documento.receptor.codigoPostalCliente,
                        Departamento = documento.receptor.departamentoCliente,
                        Direccion = documento.receptor.direccionCliente,
                        Municipio = documento.receptor.municipioCliente,
                        Pais = (tipoDireccionPais)Enum.Parse(typeof(tipoDireccionPais), documento.receptor.paisCliente)
                    }
                };

                // detalles
                GTDocumentoSATDTEDatosEmisionItem[] items = new GTDocumentoSATDTEDatosEmisionItem[documento.detalles.Count];
                GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto[] impuestos = null;
                decimal totalMontoImpuesto = 0;
                decimal granTotal = 0;

                if (documento.general.tipoDocumento != "NABN")
                {
                    for (int i = 0; i < documento.detalles.Count; i++)
                    {
                        var linea = documento.detalles[i];

                        GTDocumentoSATDTEDatosEmisionItem item = new GTDocumentoSATDTEDatosEmisionItem()
                        {
                            BienOServicio = (GTDocumentoSATDTEDatosEmisionItemBienOServicio)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionItemBienOServicio), linea.bienOServicio),
                            NumeroLinea = linea.numeroLinea,
                            UnidadMedida = linea.unidadDeMedida,
                            Descripcion = linea.descripcion,
                            PrecioUnitario = Convert.ToDecimal(linea.precioUnitario),
                            Precio = Convert.ToDecimal(linea.precioXCantidad),
                            Descuento = Convert.ToDecimal(linea.descuento),
                            DescuentoSpecified = true,
                            Cantidad = new GTDocumentoSATDTEDatosEmisionItemCantidad(Convert.ToDecimal(linea.cantidad)),
                            Total = Convert.ToDecimal(Convert.ToDecimal(linea.total).ToString("N6")),
                            Impuestos = new GTDocumentoSATDTEDatosEmisionItemImpuesto[1]
                        {
                    new GTDocumentoSATDTEDatosEmisionItemImpuesto() {
                        NombreCorto = GTDocumentoSATDTEDatosEmisionItemImpuestoNombreCorto.IVA,
                        CodigoUnidadGravable = linea.impuestos[0].codigoUnidadGravable,
                        MontoGravable = Convert.ToDecimal(linea.impuestos[0].montoGravable),
                        MontoGravableSpecified = true,
                        MontoImpuesto = new GTDocumentoSATDTEDatosEmisionItemImpuestoMontoImpuesto()
                        {
                            Value = Convert.ToDecimal(linea.impuestos[0].montoImpuesto)
                        }
                    }
                        }
                        };
                        items[i] = item;
                        totalMontoImpuesto += Convert.ToDecimal(linea.impuestos[0].montoImpuesto);
                        granTotal += Convert.ToDecimal((Convert.ToDecimal(linea.total)).ToString("N6"));
                    }
                    impuestos = new GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto[]
                    {
                new GTDocumentoSATDTEDatosEmisionTotalesTotalImpuesto()
                {
                    NombreCorto = GTDocumentoSATDTEDatosEmisionItemImpuestoNombreCorto.IVA,
                    TotalMontoImpuesto = totalMontoImpuesto
                }
                    };
                }
                else
                {
                    for (int i = 0; i < documento.detalles.Count; i++)
                    {
                        var linea = documento.detalles[i];

                        GTDocumentoSATDTEDatosEmisionItem item = new GTDocumentoSATDTEDatosEmisionItem()
                        {
                            BienOServicio = (GTDocumentoSATDTEDatosEmisionItemBienOServicio)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionItemBienOServicio), linea.bienOServicio),
                            NumeroLinea = linea.numeroLinea,
                            UnidadMedida = linea.unidadDeMedida,
                            Descripcion = linea.descripcion,
                            PrecioUnitario = Convert.ToDecimal(linea.precioUnitario),
                            Precio = Convert.ToDecimal(linea.precioXCantidad),
                            Descuento = Convert.ToDecimal(linea.descuento),
                            DescuentoSpecified = true,
                            Cantidad = new GTDocumentoSATDTEDatosEmisionItemCantidad(Convert.ToDecimal(linea.cantidad)),
                            Total = Convert.ToDecimal(Convert.ToDecimal(linea.total).ToString("N6")),
                            Impuestos = null
                        };
                        items[i] = item;
                        totalMontoImpuesto = 0;
                        granTotal += Convert.ToDecimal((Convert.ToDecimal(linea.total) - Convert.ToDecimal(linea.descuento)).ToString("N6"));
                    }
                }



                // totales
                GTDocumentoSATDTEDatosEmisionTotales totales = new GTDocumentoSATDTEDatosEmisionTotales()
                {
                    GranTotal = granTotal,
                    TotalImpuestos = impuestos
                };

                // complementos
                GTDocumentoSATDTEDatosEmisionComplementos complementos = null;

                GTDocumentoSATDTEDatosEmisionComplementosComplemento complementoFcam = null;
                GTDocumentoSATDTEDatosEmisionComplementosComplemento complementoExp = null;

                //SI ES FACTURA CAMBIARIA DE EXPORTACION
                if ((documento.general.tipoDocumento == "FCAM" || documento.general.tipoDocumento == "FACT") && documento.general.exp == "Exp")
                {
                    //FACTURA CAMBIARIA
                    if (documento.general.tipoDocumento == "FCAM")
                    {
                        AbonosFacturaCambiaria abono = new AbonosFacturaCambiaria()
                        {
                            Abono = new AbonosFacturaCambiariaAbono[] {
                new AbonosFacturaCambiariaAbono()
                {

                    FechaVencimiento = Convert.ToDateTime(documento.complementoCambiaria.fechaVencimiento).Date,
                    MontoAbono = (float)granTotal,
                    NumeroAbono = 1
                }
            }
                        };

                        complementoFcam = new GTDocumentoSATDTEDatosEmisionComplementosComplemento()
                        {
                            NombreComplemento = "Abono 1",
                            IDComplemento = "A1",
                            URIComplemento = "",
                            Any = XMLHelper.Serialize(typeof(AbonosFacturaCambiaria), abono)
                        };

                    }

                    //FACTURA EXPORTACION
                    Exportacion exportacion = new Exportacion()
                    {

                        NombreConsignatarioODestinatario = documento.complementoExportacion.nombreconsignatarioDestino,
                        DireccionConsignatarioODestinatario = documento.complementoExportacion.direccionConsignatarioDestino,
                        CodigoConsignatarioODestinatario = documento.complementoExportacion.codigoConsignatarioDestino,
                        NombreComprador = documento.complementoExportacion.nombreComprador,
                        DireccionComprador = documento.complementoExportacion.direccionComprador,
                        CodigoComprador = documento.complementoExportacion.codigoExportador,
                        OtraReferencia = documento.complementoExportacion.otraReferencia,
                        INCOTERM = (INCOTERMType)Enum.Parse(typeof(INCOTERMType), documento.complementoExportacion.incoterm),
                        NombreExportador = documento.complementoExportacion.nombreExportador,
                        CodigoExportador = documento.complementoExportacion.codigoExportador
                    };

                    complementoExp = new GTDocumentoSATDTEDatosEmisionComplementosComplemento()
                    {
                        NombreComplemento = "EXP1",
                        IDComplemento = "E1",
                        URIComplemento = "",
                        Any = XMLHelper.Serialize(typeof(Exportacion), exportacion)
                    };

                    complementos = new GTDocumentoSATDTEDatosEmisionComplementos()
                    {
                        Complemento = new GTDocumentoSATDTEDatosEmisionComplementosComplemento[] { complementoExp, complementoFcam }

                    };


                } // FIN SI ES FACTURA CAMBIARIA O EXPORACION


                //SI ES FACTURA CAMBIARIA UNICAMENTE
                if (documento.general.tipoDocumento == "FCAM" && documento.complementoCambiaria != null && documento.general.exp != "Exp")
                {



                    //FACTURA CAMBIARIA
                    AbonosFacturaCambiaria abono = new AbonosFacturaCambiaria()
                    {
                        Abono = new AbonosFacturaCambiariaAbono[] {
                new AbonosFacturaCambiariaAbono()
                {

                    FechaVencimiento = Convert.ToDateTime(documento.complementoCambiaria.fechaVencimiento).Date,
                    MontoAbono = (float)granTotal,
                    NumeroAbono = 1
                }
            }
                    };

                    complementoFcam = new GTDocumentoSATDTEDatosEmisionComplementosComplemento()
                    {
                        NombreComplemento = "Abono 1",
                        IDComplemento = "A1",
                        URIComplemento = "",
                        Any = XMLHelper.Serialize(typeof(AbonosFacturaCambiaria), abono)
                    };
                    complementos = new GTDocumentoSATDTEDatosEmisionComplementos()
                    {
                        Complemento = new GTDocumentoSATDTEDatosEmisionComplementosComplemento[] { complementoFcam }
                    };



                }


                else if (documento.general.tipoDocumento == "NCRE" || documento.general.tipoDocumento == "NDEB")
                {
                    bool regimenSpecified = false;
                    if (documento.complementoNotas.regimenAntiguo != string.Empty)
                    {
                        regimenSpecified = true;
                    }
                    ReferenciasNota referenciasNota;
                    if (regimenSpecified == true)
                    {
                        referenciasNota = new ReferenciasNota()
                        {
                            RegimenAntiguo = (ReferenciasNotaRegimenAntiguo)Enum.Parse(typeof(ReferenciasNotaRegimenAntiguo), documento.complementoNotas.regimenAntiguo),
                            RegimenAntiguoSpecified = true,
                            NumeroAutorizacionDocumentoOrigen = documento.complementoNotas.numeroAutrizacionDcumento,
                            FechaEmisionDocumentoOrigen = Convert.ToDateTime(documento.complementoNotas.fechaEmisionDocumentoOrigen).Date,
                            MotivoAjuste = documento.complementoNotas.motivoAjuste,
                            SerieDocumentoOrigen = documento.complementoNotas.serieDocumentoOrigen,
                            NumeroDocumentoOrigen = documento.complementoNotas.numeroDocumentoOrigen
                        };
                    }
                    else
                    {
                        referenciasNota = new ReferenciasNota()
                        {

                            RegimenAntiguoSpecified = false,
                            NumeroAutorizacionDocumentoOrigen = documento.complementoNotas.numeroAutrizacionDcumento,
                            FechaEmisionDocumentoOrigen = Convert.ToDateTime(documento.complementoNotas.fechaEmisionDocumentoOrigen).Date,
                            MotivoAjuste = documento.complementoNotas.motivoAjuste

                        };
                    }


                    GTDocumentoSATDTEDatosEmisionComplementosComplemento complemento = new GTDocumentoSATDTEDatosEmisionComplementosComplemento()
                    {
                        NombreComplemento = "NOTA1",
                        IDComplemento = "N1",
                        URIComplemento = "",
                        Any = XMLHelper.Serialize(typeof(ReferenciasNota), referenciasNota)
                    };

                    complementos = new GTDocumentoSATDTEDatosEmisionComplementos()
                    {
                        Complemento = new GTDocumentoSATDTEDatosEmisionComplementosComplemento[] { complemento }
                    };

                } // NOTAS DE CREDITO, DEBITO Y ABONO



                else if (documento.general.tipoDocumento == "FESP")
                {
                    RetencionesFacturaEspecial complemFesp = new RetencionesFacturaEspecial()
                    {
                        RetencionISR = float.Parse(documento.complementoEspecial.retencionISR),
                        RetencionIVA = float.Parse(documento.complementoEspecial.retencionIVA),
                        RetencionIVASpecified = true,
                        TotalMenosRetenciones = float.Parse(documento.complementoEspecial.totalMenosRetencones),
                    };

                    GTDocumentoSATDTEDatosEmisionComplementosComplemento complemento = new GTDocumentoSATDTEDatosEmisionComplementosComplemento()
                    {
                        NombreComplemento = "FESP1",
                        IDComplemento = "FESP1",
                        URIComplemento = "",
                        Any = XMLHelper.Serialize(typeof(AbonosFacturaCambiaria), complemFesp)
                    };

                    complementos = new GTDocumentoSATDTEDatosEmisionComplementos()
                    {
                        Complemento = new GTDocumentoSATDTEDatosEmisionComplementosComplemento[] { complemento }
                    };

                } // FACTURA ESPECIAL



                //Adenda
                AdendaDetailAdendaSummary summary = new AdendaDetailAdendaSummary()
                {
                    Valor1 = documento.addendaResumen.valor1,
                    Valor2 = documento.addendaResumen.valor2,
                    Valor3 = documento.addendaResumen.valor3,
                    Valor4 = documento.addendaResumen.valor4,
                    Valor5 = documento.addendaResumen.valor5,
                    Valor6 = documento.addendaResumen.valor6,
                    Valor7 = documento.addendaResumen.valor7,
                    Valor8 = documento.addendaResumen.valor8,
                    Valor9 = documento.addendaResumen.valor9,
                    Valor10 = documento.addendaResumen.valor10,
                    Valor11 = documento.addendaResumen.valor11,
                    Valor12 = documento.addendaResumen.valor12,
                    Valor13 = documento.addendaResumen.valor13,
                    Valor14 = documento.addendaResumen.valor14,
                    Valor15 = documento.addendaResumen.valor15,
                    Valor16 = documento.addendaResumen.valor16
                };

                AdendaDetailAdendaItem[] adendaItems = new AdendaDetailAdendaItem[documento.detalles.Count];
                {
                    AdendaDetailAdendaItem adendaDetailItem;
                    for (int i = 0; i < documento.detalles.Count; i++)
                    {
                        var linea = documento.detalles[i];
                        adendaDetailItem = new AdendaDetailAdendaItem() { LineaReferencia = linea.numeroLinea, Valor1 = documento.addendaItems[i].valor1, Valor2 = documento.addendaItems[i].valor2, Valor3 = documento.addendaItems[i].valor3, Valor4 = documento.addendaItems[i].valor4, Valor5 = documento.addendaItems[i].valor5, Valor6 = documento.addendaItems[i].valor6, Valor7 = documento.addendaItems[i].valor7 };
                        adendaItems[i] = adendaDetailItem;
                    }

                }

                AdendaDetail adenda = new AdendaDetail() { AdendaSummary = summary, AdendaItems = adendaItems };
                GTDocumentoSATDTEDatosEmisionFrase[] frases = null;

                // frases
                if (documento.general.tipoDocumento == "FCAM")
                {
                    frases = new GTDocumentoSATDTEDatosEmisionFrase[documento.frases.Count];
                    for (int i = 0; i < frases.Length; i++)
                    {
                        frases[i] = new GTDocumentoSATDTEDatosEmisionFrase()
                        {
                            CodigoEscenario = int.Parse(documento.frases[i].codigoFrases),
                            TipoFrase = documento.frases[i].tipoFrases
                        };
                    }
                }
                else if (documento.general.tipoDocumento == "FACT")
                {
                    frases = new GTDocumentoSATDTEDatosEmisionFrase[documento.frases.Count];
                    for (int i = 0; i < frases.Length; i++)
                    {
                        frases[i] = new GTDocumentoSATDTEDatosEmisionFrase()
                        {
                            CodigoEscenario = int.Parse(documento.frases[i].codigoFrases),
                            TipoFrase = documento.frases[i].tipoFrases
                        };
                    }
                }

                GTDocumentoSATDTEDatosEmision datosEmision = new GTDocumentoSATDTEDatosEmision()
                {
                    Emisor = emisor,
                    Receptor = receptor,
                    Complementos = complementos,
                    DatosGenerales = datosGenerales,
                    Items = items,
                    Totales = totales,
                    Frases = frases
                };

                GTDocumentoSATDTE dte = new GTDocumentoSATDTE()
                {
                    DatosEmision = datosEmision
                };
                GTDocumento.GTDocumento GTDocumento = new GTDocumento.GTDocumento()
                {
                    SAT = new GTDocumentoSAT()
                    {
                        DTE = dte,
                        ClaseDocumento = GTDocumentoSATClaseDocumento.dte,
                        Adenda = new GTDocumentoSATAdenda() { Any = new XmlElement[] { XMLHelper.Serialize(typeof(AdendaDetail), adenda) } }
                    }
                };
                result = XMLHelper.SerializeToString(typeof(GTDocumento.GTDocumento), GTDocumento);
                response.Object = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }


            return response;
        }

    }
}
