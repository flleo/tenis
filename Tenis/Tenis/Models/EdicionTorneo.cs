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
    
    public partial class EdicionTorneo
    {
        public int id { get; set; }
        public Nullable<int> IdTorneo { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> Njugadores { get; set; }
        public Nullable<double> premios { get; set; }
        public Nullable<int> Ganador { get; set; }
    
        public virtual Jugador Jugador { get; set; }
        public virtual Torneo Torneo { get; set; }
    }
}