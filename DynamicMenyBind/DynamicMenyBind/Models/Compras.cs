//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DynamicMenyBind.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compras
    {
        public int ComID { get; set; }
        public System.DateTime ComFecha { get; set; }
        public decimal Comtotal { get; set; }
        public int UsuId { get; set; }
        public Nullable<decimal> ComDescuento { get; set; }
        public Nullable<System.DateTime> ComFechaActualizacion { get; set; }
        public string rowid { get; set; }
    }
}
