using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{ 
    public class Catalogue
    {
        public int CatalogueId { get; set; }
        [Display(Name = "Nom du Catalogue")]
        public string NomCatalogue { get; set; }
        public virtual ICollection<Produit> produits { get; set; }
    }
}