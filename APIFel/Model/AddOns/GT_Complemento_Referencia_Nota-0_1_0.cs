﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.7.2558.0.
// 
namespace AddOns
{
    using System.Xml.Serialization;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0", IsNullable = false)]
    public partial class ReferenciasNota
    {

        private decimal versionField;

        private ReferenciasNotaRegimenAntiguo regimenAntiguoField;
        //private string regimenAntiguoField;

        private bool regimenAntiguoFieldSpecified;

        private string numeroAutorizacionDocumentoOrigenField;

        private System.DateTime fechaEmisionDocumentoOrigenField;

        private string motivoAjusteField;

        private string serieDocumentoOrigenField;

        private string numeroDocumentoOrigenField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ReferenciasNotaRegimenAntiguo RegimenAntiguo
        {
            get
            {
                return this.regimenAntiguoField;
            }
            set
            {
                this.regimenAntiguoField = value;
            }
        }
        //public string RegimenAntiguo
        //{
        //    get
        //    {
        //        return this.regimenAntiguoField;
        //    }
        //    set
        //    {
        //        this.regimenAntiguoField = value;
        //    }
        //}


        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RegimenAntiguoSpecified
        {
            get
            {
                return this.regimenAntiguoFieldSpecified;
            }
            set
            {
                this.regimenAntiguoFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string NumeroAutorizacionDocumentoOrigen
        {
            get
            {
                return this.numeroAutorizacionDocumentoOrigenField;
            }
            set
            {
                this.numeroAutorizacionDocumentoOrigenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime FechaEmisionDocumentoOrigen
        {
            get
            {
                return this.fechaEmisionDocumentoOrigenField;
            }
            set
            {
                this.fechaEmisionDocumentoOrigenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MotivoAjuste
        {
            get
            {
                return this.motivoAjusteField;
            }
            set
            {
                this.motivoAjusteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SerieDocumentoOrigen
        {
            get
            {
                return this.serieDocumentoOrigenField;
            }
            set
            {
                this.serieDocumentoOrigenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NumeroDocumentoOrigen
        {
            get
            {
                return this.numeroDocumentoOrigenField;
            }
            set
            {
                this.numeroDocumentoOrigenField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0")]
    public enum ReferenciasNotaRegimenAntiguo
    {

        /// <remarks/>
        Antiguo,
    }
}
