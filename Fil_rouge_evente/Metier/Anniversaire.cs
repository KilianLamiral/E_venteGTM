using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class Anniversaire
    {
        public int AnniversaireId { get; set; }
        
        public decimal montant { get; set; }

        public virtual ICollection<AnniversaireClient> anniversaireClients { get; set; }
    }
}