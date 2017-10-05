using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DynamicMenyBind.Models
{
    public class LoginModels
    {
        public int UsuID { get; set; }
        [Required(ErrorMessage = "Please enter the User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
        [DataType(DataType.Password)]
        public string UserPass { get; set; }
        public int? RolID { get; set; }
        public string RoleName { get; set; }

        public virtual Roles Rol { get; set; }
    }
}