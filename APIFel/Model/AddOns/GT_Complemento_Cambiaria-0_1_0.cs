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
namespace AddOns {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.gt/dte/fel/CompCambiaria/0.1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.sat.gob.gt/dte/fel/CompCambiaria/0.1.0", IsNullable=false)]
    public partial class AbonosFacturaCambiaria {
        
        private AbonosFacturaCambiariaAbono[] abonoField;
        
        private string versionField;
        
        public AbonosFacturaCambiaria() {
            this.versionField = "1";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Abono")]
        public AbonosFacturaCambiariaAbono[] Abono {
            get {
                return this.abonoField;
            }
            set {
                this.abonoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.gt/dte/fel/CompCambiaria/0.1.0")]
    public partial class AbonosFacturaCambiariaAbono {
        
        private int numeroAbonoField;
        
        private System.DateTime fechaVencimientoField;
        
        private float montoAbonoField;
        
        /// <remarks/>
        public int NumeroAbono {
            get {
                return this.numeroAbonoField;
            }
            set {
                this.numeroAbonoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime FechaVencimiento {
            get {
                return this.fechaVencimientoField;
            }
            set {
                this.fechaVencimientoField = value;
            }
        }
        
        /// <remarks/>
        public float MontoAbono {
            get {
                return this.montoAbonoField;
            }
            set {
                this.montoAbonoField = value;
            }
        }
    }
}
