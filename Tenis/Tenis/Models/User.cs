//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tenis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string user1 { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string password { get; set; }
        public int idTipoUsuario { get; set; }
    
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
