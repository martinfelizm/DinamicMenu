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
    
    public partial class Productos
    {
        public int ProId { get; set; }
        public System.DateTime ProFecha { get; set; }
        public string ProNombre { get; set; }
        public Nullable<decimal> ProCantidad { get; set; }
        public Nullable<decimal> ProPrecio { get; set; }
        public int CatId { get; set; }
        public Nullable<System.DateTime> ProFechaActualizacion { get; set; }
        public int UsuId { get; set; }
        public string rowid { get; set; }
    }
}
