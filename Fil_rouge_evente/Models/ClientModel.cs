using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Models
{
    public class ClientModel
    {
        public int UtilisateurId { get; set; }
        [Required(ErrorMessage = "Nom manquant")]
        [Column("Nom", TypeName = "varchar"), MinLength(2), MaxLength(50)]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Prenom manquant")]
        [Column("Prenom", TypeName = "varchar"), MinLength(2), MaxLength(50)]
        [Display(Name = "Prénom")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Le champ Prenom doit être compris entre 5 et 20 caractères")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ « date de naissance » est obligatoire")]
        [Display(Name = "Né(e) le")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "Le champ PASSWORD est obligatoire")]
        [Column("Password", TypeName = "varchar"), MinLength(6), MaxLength(50)]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Le champ CONFIRMATION est obligatoire")]
        [Display(Name = "Confirmez votre mot de passe")]
        [Compare("password", ErrorMessage = "Le mot de passe n'est pas identique")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

        [Required(ErrorMessage = "Le champ EMAIL est obligatoire")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ce champ doit contenir un Email valide")]
        [Column("Email", TypeName = "varchar")]
        [Index("EmailIndex", IsUnique = true)]
        public string Email { get; set; }
        public virtual ICollection<AdresseClient> clientAdresses { get; set; }
        public int RoleId { get; set; }

        [Display(Name = "Numéro de la rue")]
        public string NumeroRue { get; set; }

        [Display(Name = "Nom de la rue")]
        public string NomDeRue { get; set; }

        [Display(Name = "Code Postal")]
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }

        [Display(Name = "Numéro carte fidélité")]
        public int NumeroCarteFidelite { get; set; }

        [Display(Name = "Nombre de points")]
        public int NombrePoints { get; set; }

        public bool CompteActif { get; set; }

        [Display(Name = "Compte à supprimer")]
        public bool CompteASupprimer { get; set; }
        public enum Civilite { Mademoiselle, Madame, Monsieur };

        [Required(ErrorMessage = "La Civilité est obligatoire")]
        [Display(Name = "Civilité")]
        public Civilite civilite { get; set; }
        public enum TypeAdresse { Livraison, Facturation };

        [Display(Name = "Type d'adresse")]
        public TypeAdresse typeadresse { get; set; }
    }
}