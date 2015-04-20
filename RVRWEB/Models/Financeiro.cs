using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RVRWEB.Models
{
    public class Financeiro
    {
        [Key()]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int FinanceiroID { get; set; }
        public DateTime Dia { get; set; }
        public string Comprovante { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public double Valor { get; set; }


        //[ForeignKey("TipoPgt")]
        //public int TipoPgtID { get; set; }
        public virtual TipoPgt TipoPgt { get; set; }


        //[ForeignKey("GrupoPgt")]
        //public int GrupoPgtID { get; set; }
        public IList<GrupoPgt> GrupoPgt { get; set; }

        public virtual ApplicationUser _ApplicationUser { get; set; }
    }

    public class TipoPgt
    {
        [Key()]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int TipoPgtID { get; set; }
        [Display(Name="Pagamento")]
        public string Nome { get; set; }
        public IList<Financeiro> Financeiro { get; set; }

        public virtual ApplicationUser _ApplicationUser { get; set; }
    }

    public class GrupoPgt
    {
        [Key()]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int GrupoPgtID { get; set; }
        public string Grupo { get; set; }
        [Display(Name="Descrição")]
        public string Descricao { get; set; }
        public IList<Financeiro> Financeiro { get; set; }

        public virtual ApplicationUser _ApplicationUser { get; set; }
    }

}