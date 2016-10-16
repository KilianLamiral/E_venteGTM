using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class Commande
    {
        public int CommandeId { get; set; }
        public string Commentaire { get; set; }
        [Required]
        public DateTime DateCommande { get; set; }

        public int UtilisateurId { get; set; }
        public virtual Client client { get; set; }

        //public virtual ICollection<Client> clients { get; set; }

        public int StatutCommandeId { get; set; }
        public virtual StatutCommande statut { get; set; }

        public virtual ICollection<ProduitCommande> produitCommandes { get; set; }
    }
}