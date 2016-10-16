using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Models
{
    public class ModelAnnivClient
    {
        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [Display(Name = "Date de naissance")]
        public DateTime DateNaissance { get; set; }

        public int AnniversaireId { get; set; }

        public decimal montant { get; set; }

        public virtual ICollection<AnniversaireClient> anniversaireClients { get; set; }

        public int UtilisateurId { get; set; }

        public int PanierId { get; set; }
        public int NombreProduits { get; set; }
        [Column("Prixtotal", TypeName = "money")]
        public decimal PrixTotal { get; set; }
    }
}