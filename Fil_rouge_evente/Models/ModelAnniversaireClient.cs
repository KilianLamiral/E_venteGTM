using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Models
{
    public class ModelAnniversaireClient
    {
        //from anniversaire
        public int AnniversaireId { get; set; }

        public decimal montant { get; set; }

        public virtual ICollection<AnniversaireClient> anniversaireClients { get; set; }

        //from Client
        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [Display(Name = "Date de naissance")]
        public DateTime DateNaissance { get; set; }
        public bool Actif { get; set; }
        public int? NumeroCarteFidelite { get; set; }
        public int NombrePoints { get; set; }
        public bool CompteASupprimer { get; set; }

        public enum Civilite { Mademoiselle, Madame, Monsieur };
        [Required(ErrorMessage = "La Civilité est obligatoire")]
        [Display(Name = "Civilité")]
        public Civilite civilite { get; set; }

        public virtual ICollection<Commande> commandes { get; set; }
        public virtual ICollection<FideliteClient> clientFidelités { get; set; }
        public virtual ICollection<Avis_ClientProduit> avis_clientProduit { get; set; }
        public virtual ICollection<AnniversaireClient> clientAnniversaires { get; set; }
        public virtual ICollection<AdresseClient> clientAdresses { get; set; }
        public virtual ICollection<AbonnementClient> clientAbonnements { get; set; }
        public virtual ICollection<MoyenPaiement> moyenPaiements { get; set; }
    }
}