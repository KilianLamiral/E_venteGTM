using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class AbonnementClient
    {
        [Key, Column(Order = 0)]
        public int AbonnementId { get; set; }
        [Key, Column(Order = 1)]
        public int UtilisateurId { get; set; }
        public DateTime DateDebut { get; set; }
       
        public DateTime DateFin { get; set; }
        public virtual Abonnement abonnement { get; set; }
        public virtual Client client { get; set; }
    }
}