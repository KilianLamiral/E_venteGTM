using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Models
{
    public class ProduitCatalogueModel
    {
        public int ProduitId { get; set; }
        [Display(Name="Nom du produit")]
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public string Categorie { get; set; }
        [Display(Name ="Nom du Catalogue")]
        public string NomCatalogue { get; set; }

        public string Path { get; set; }

    }
}