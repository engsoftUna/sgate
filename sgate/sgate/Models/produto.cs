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
    using System.ComponentModel.DataAnnotations;
    
    public partial class produto
    {
        public produto()
        {
            this.itenspacote = new HashSet<itenspacote>();
        }
        
        [Display(Name = "C�digo")]
        public int idproduto { get; set; }
        
        [Required]
        [Display(Name = "Descri�ao")]
        [StringLength(50, ErrorMessage = "Campo permite somente 50 caracteres.")]
        public string descricao { get; set; }
        
        [Required]
        [Display(Name = "Data de Expira��o")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> dataexpiracao { get; set; }
        
        [Required]
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> valorproduto { get; set; }
        
        [Required]
        [Display(Name = "Tipo de Produto")]
        public Nullable<int> idtipo { get; set; }

        public virtual tipoproduto tipoproduto { get; set; }
        public virtual ICollection<itenspacote> itenspacote { get; set; }
    }
}
