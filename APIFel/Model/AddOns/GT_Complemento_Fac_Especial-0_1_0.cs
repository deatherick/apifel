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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.gt/face2/ComplementoFacturaEspecial/0.1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.gt/face2/ComplementoFacturaEspecial/0.1.0", IsNullable = false)]
    public partial class RetencionesFacturaEspecial
    {

        private float retencionISRField;

        private float retencionIVAField;

        private bool retencionIVAFieldSpecified;

        private float totalMenosRetencionesField;

        private string versionField;

        public RetencionesFacturaEspecial()
        {
            this.versionField = "1";
        }

        /// <remarks/>
        public float RetencionISR
        {
            get
            {
                return this.retencionISRField;
            }
            set
            {
                this.retencionISRField = value;
            }
        }

        /// <remarks/>
        public float RetencionIVA
        {
            get
            {
                return this.retencionIVAField;
            }
            set
            {
                this.retencionIVAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RetencionIVASpecified
        {
            get
            {
                return this.retencionIVAFieldSpecified;
            }
            set
            {
                this.retencionIVAFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float TotalMenosRetenciones
        {
            get
            {
                return this.totalMenosRetencionesField;
            }
            set
            {
                this.totalMenosRetencionesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version
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
    }
}