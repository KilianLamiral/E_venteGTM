using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class Adresse
    {
        public int AdresseId { get; set; }

        [Display(Name = "Numéro de la rue")]
        public string NumeroRue { get; set; }

        [Display(Name = "Nom de la rue")]
        public string NomRue { get; set; }

        [Display(Name = "Code Postal")]
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public enum TypeAdresse { Livraison, Facturation };

        [Display(Name = "Type d'adresse")]
        public TypeAdresse typeadresse { get; set; }

        public virtual ICollection<AdresseClient> adresseClients { get; set; }
    }
}