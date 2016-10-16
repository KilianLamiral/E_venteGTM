using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Models
{
    public class Historique_UtilisateurProduitModel
    {
        [Display(Name = "Nom du produit")]
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        [Display(Name = "Catégorie")]
        public string Categorie { get; set; }
        [Display(Name = "Date de consultation")]
        [DisplayFormat(DataFormatString = "{0:dd / MM / yyyy}")]
        public DateTime DateConsultation { get; set; }
    }
}