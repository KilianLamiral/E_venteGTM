using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class CarteBancaire:MoyenPaiement
    {
        [Required(ErrorMessage ="Ce champ est obligatoire")]
        [Display(Name ="Nom du propiétaire")]
        public string NomProprietaire { get; set; }
        [Required(ErrorMessage ="Ce champ est obligatoire")]
        [MaxLength(16,ErrorMessage ="Le numéro de la carte bancaire ne peut pas avoir plus de 16 chiffres")]
        [MinLength(16, ErrorMessage = "Le numéro de la carte bancaire ne peut pas avoir moins de 16 chiffres")]
        [Display(Name ="Numéro de la carte")]
        public string NumeroCarte { get; set; }
        
        [Required]
       
        public int Mois { get; set; }
        [Required]
       
        public int Annee { get; set; }
        
    }
}