using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class ProduitCommande
    {
        [Key, Column(Order = 0)]
        public int ProduitId { get; set; }
        [Key, Column(Order = 1)]
        public int PanierId { get; set; }
        public virtual Panier panier { get; set; }
        public virtual Produit produit { get; set; }
        public virtual Commande commande { get; set; }

        
       

        public int quantite { get; set; }
        
    }
}