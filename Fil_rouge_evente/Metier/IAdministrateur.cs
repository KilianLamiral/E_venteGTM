using Fil_rouge_evente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fil_rouge_evente.Metier
{
    interface IAdministrateur: IUtilisateur
    {
        Administrateur creationCompteAdmin(Administrateur a);
        Produit ajouterProduit(Produit p);
        void supprimerProduit(int ProduitId);
        Produit modifierProduit(Produit p);
        void suppressionCompte(int UtilisateurId);
        Role ajouterRole(Role r);
        ICollection<AdresseClientModel> listerAdresseClient();
        Promotion creerPromotion(Promotion p);
        void supprimerPromotion(int PromotionId);
        Promotion modifierPromotion(Promotion p);
        Promotion findPromotionbyId(int id);
        Catalogue ajouterCatalogue(Catalogue c);
        void modifierCatalogue(Catalogue c);
        Catalogue afficherCatalogue(int CatalogueId);
        void supprimerCatalogue(int CatalogueId);
        ICollection<Catalogue> listerCatalogue();
        ICollection<Produit> rechercherProduitById(int id);
        ICollection<Role> listerRoles();
        ICollection<Utilisateur> listerComptes();
        Abonnement creerAbonnement(Abonnement a);
        void supprimerAbonnement(int AbonnementId);
        ICollection<Abonnement> listerTousAbonnements();
        Abonnement modifierAbonnement(Abonnement a);
        Abonnement afficherAbonnement(int AbonnementId);
        Administrateur modifierCompteAdmin(Administrateur a);
        Anniversaire ajouterAnniversaire(Anniversaire a);
        ICollection<Anniversaire> listerAnniversaires();
        void supprimerAnniversaire(int AnniversaireId);
        Anniversaire modifierAnniversaire(Anniversaire a);
        Fidelite ajouterFidelite(Fidelite f);
        void supprimerFidelite(int FideliteId);
        Fidelite modifierFidelite(Fidelite f);
        ICollection<Fidelite> listerFidelite();

        //fonctionnalite catalogue ajout le 12/10/2016 a 14h00
        Catalogue findCatalogue(int id);
       
        ICollection<Catalogue> findAllCatalogue();
       

       

        
        Promotion ajouterPromotion(Promotion p);
        ICollection<Promotion> findAllPromotion();
        ICollection<Promotion> getProduitIdPromo(string nameProduit);
        ICollection<Client> listerClient();
        ICollection<Client> rechercherClientByName(string name);
        void changerEtatClient(int idClient);

    }
}
