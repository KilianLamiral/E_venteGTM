using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class Client: Utilisateur
    {
        [Required(ErrorMessage = "Le champ « date de naissance » est obligatoire")]
        [Display(Name = "Né(e) le")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }

        [Display(Name = "Numéro carte fidélité")]
        public int? NumeroCarteFidelite { get; set; }

        [Display(Name = "Nombre de points")]
        public int NombrePoints { get; set; }

        [Display(Name = "Compte à supprimer")]
        public bool CompteASupprimer { get; set; }
        
        public enum Civilite { Mademoiselle, Madame, Monsieur };
        [Required(ErrorMessage ="La Civilité est obligatoire")]
        [Display(Name ="Civilité")]
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