//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sgate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipoproduto
    {
        public tipoproduto()
        {
            this.produto = new HashSet<produto>();
        }
    
        public int idtipo { get; set; }
        public string tipo { get; set; }
    
        public virtual ICollection<produto> produto { get; set; }
    }
}
