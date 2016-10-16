using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Models
{
    public class AdresseClientModel
    {
        public int UtilisateurId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NumeroRue { get; set; }
        public string NomRue { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
    }
}