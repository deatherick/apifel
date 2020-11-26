using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTDocumento
{
    /// <summary>
    /// agregando metodos a objeto GTDocumentoSATDTEDatosEmisionItemImpuesto
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionItemImpuesto
    {
        public void setValues(string nombreCorto, string codigoUnidadGravable, decimal montoGravable, decimal cantidadUnidadesGravables, decimal montoImpuesto)
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
    /// agregando metodos a objeto GTDocumentoSATDTEDatosEmisionItem
    /// </summary>
    public partial class GTDocumentoSATDTEDatosEmisionItem
    {
        public void setValues(string bienOServicio, string numeroLinea, string unidadMedida, string descripcion, decimal precioUnitario, decimal precio, decimal descuento, decimal cantidad, decimal total, GTDocumentoSATDTEDatosEmisionItemImpuesto[] impuestos)
        {
            this.BienOServicio = (GTDocumentoSATDTEDatosEmisionItemBienOServicio)Enum.Parse(typeof(GTDocumentoSATDTEDatosEmisionItemBienOServicio), bienOServicio);
            this.NumeroLinea = numeroLinea;
            this.UnidadMedida = unidadMedida;
            this.Descripcion = descripcion;
            this.PrecioUnitario = precioUnitario;
            this.Precio = precio;
            this.DescuentoSpecified = true;
            this.Descuento = descuento;
            this.Cantidad = new GTDocumentoSATDTEDatosEmisionItemCantidad(cantidad);
            this.Total = total;
            this.Impuestos = impuestos;
        }

        public void setValues(string bienOServicio, string numeroLinea, string unidadMedida, string descripcion, decimal precioUnitario, decimal precio, decimal descuento, decimal cantidad, decimal total)
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
        }
    }
}