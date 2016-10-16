using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class Panier
    {
        public int PanierId { get; set; }
        public int NombreProduits { get; set; }
        [Column("Prixtotal", TypeName = "money")]
        public decimal PrixTotal { get; set; }


        public virtual ICollection<ProduitCommande> produitCommandes { get; set; }
    }
}