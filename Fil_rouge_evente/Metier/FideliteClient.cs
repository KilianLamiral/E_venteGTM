using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class FideliteClient
    {
        [Key, Column(Order = 0)]
        public int FideliteId { get; set; }
        [Key, Column(Order = 1)]
        public int UtilisateurId { get; set; }

        public virtual Fidelite fidelite { get; set; }
        public virtual Client client { get; set; }
    }
}