using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DynamicMenyBind.Models
{
    public class LoginC
    {
        public int UsuID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public Nullable<int> RolID { get; set; }

        public virtual Roles Rol { get; set; }
        [MetadataType(typeof(LoginC))]


        public partial class Login
        { 
        }

        
    }
}