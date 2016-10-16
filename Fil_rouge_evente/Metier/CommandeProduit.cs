using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class CommandeProduit
    {
        [Key, Column(Order = 0)]
        public int CommandeId { get; set; }
        [Key, Column(Order = 1)]
        public int ProduitId { get; set; }

        public virtual Commande commande { get; set; }
        public virtual Produit produit { get; set; }
    }
}