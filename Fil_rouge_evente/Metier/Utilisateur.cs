using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Metier
{
    public class Utilisateur
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

        [Required(ErrorMessage = "Le champ EMAIL est obligatoire")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ce champ doit contenir un Email valide")]
        [Column("Email", TypeName = "varchar")]
        [Index("EmailIndex", IsUnique = true)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Le champ PASSWORD est obligatoire")]
        [Column("Password", TypeName = "varchar"), MinLength(6), MaxLength(50)]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Le champ CONFIRMATION est obligatoire")]
        [Display(Name = "Confirmez votre mot de passe")]
        [Compare("password", ErrorMessage = "Le mot de passe n'est pas identique")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string confirmPassword { get; set; }
        public bool Actif { get; set; }

        public virtual ICollection<Historique_UtilisateurProduit> historiques_UtilisateurProduit { get; set; }
        public int RoleId { get; set; }
        public virtual Role role { get; set; }

    }
}