using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class Produit
    {
        public int ProduitId { get; set; }
        [Required(ErrorMessage = "Le nom du produit est obligatoire")]
        [Display(Name = "Nom du produit")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "La catégorie est obligatoire")]
        [Display(Name ="Catégorie")]
        public string Categorie { get; set; }
        [Column("Prix", TypeName = "money")]
        [Required(ErrorMessage ="Le prix est obligatoire")]
        public decimal Prix { get; set; }
        [Required(ErrorMessage ="Le stock est obligatoire")]
        public int Stock { get; set; }

        [Required(ErrorMessage ="Une image est nécessaire")]
        public string Path { get; set; }

        public int CatalogueId { get; set; }
        [Display(Name = "Nom du Catalogue")]
        public virtual Catalogue catalogue { get; set; }

        public virtual ICollection<Promotion> promotions { get; set; }
        public virtual ICollection<Historique_UtilisateurProduit> historiques_ProduitUtilisateur { get; set; }
        public virtual ICollection<Avis_ClientProduit> avis_produitClient { get; set; }
        public virtual ICollection<ProduitCommande> produitCommande { get; set; }
    }
}