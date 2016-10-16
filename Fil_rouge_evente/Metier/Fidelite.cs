using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class Fidelite
    {
        public int FideliteId { get; set; }
        public int NombrePoints { get; set; }
        public string Avantages { get; set; }
        
        public virtual ICollection<FideliteClient> fideliteClients { get; set; }
    }
}