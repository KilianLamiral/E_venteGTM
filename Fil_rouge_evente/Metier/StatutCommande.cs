using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class StatutCommande
    {
        public int StatutCommandeId { get; set; }
        public enum TypeCommande { EnCours, EnAttente, Abandonné, Terminée };
        public TypeCommande typeCommande { get; set; }

        public virtual ICollection<Commande> commandes { get; set; }

        
    }
}