using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class AnniversaireClient
    {
        [Key, Column(Order = 0)]
        public int AnniversaireId { get; set; }
        [Key, Column(Order = 1)]
        public int UtilisateurId { get; set; }

        public virtual Anniversaire anniversaire { get; set; }
        public virtual Client client { get; set; }
        public bool Actif { get; set; }
        public bool Utilise { get; set; }
    }
}