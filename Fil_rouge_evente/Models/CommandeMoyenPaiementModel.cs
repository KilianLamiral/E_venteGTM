using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Fil_rouge_evente.Metier.MoyenPaiement;

namespace Fil_rouge_evente.Models
{
    public class CommandeMoyenPaiementModel
    {
        //public int MoyenPaiementId { get; set; }
        public int CommandeId { get; set; }
        
        public typePaiement TypePaiement { get; set; }
        public DateTime DateCommande { get; set; }
    }
}