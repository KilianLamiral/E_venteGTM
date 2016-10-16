using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public string NomPromotion { get; set; }
        public int Remise { get; set; }
        public int ProduitId { get; set; }
        public virtual Produit produit { get; set; }
    }
}