using Fil_rouge_evente.Metier;
using Fil_rouge_evente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fil_rouge_evente.Dao
{
    public interface IDAO
    {
        Client creationCompteClient(ClientModel c);
        Administrateur creationCompteAdmin(Administrateur a);
        Administrateur modifierCompteAdmin(Administrateur a);
        void suppressionCompte(int UtilisateurId);
        Utilisateur afficherCompte(int UtilisateurId);
        Utilisateur connexionCompte(Utilisateur ut);
        ICollection<Utilisateur> listerComptes();

        Client modifierCompte(Client c);
        Commande creerCommande(Commande c);
        void supprimerCommande(int CommandeId);
        ICollection<Commande> listerCommandes(int UtilisateurId);
        Commande modifierCommande(Commande c);
        Commande afficherCommande(int CommandeId);

        Produit ajouterProduit(Produit p);
        void supprimerProduit(int ProduitId);
        Produit modifierProduit(Produit p);
        ICollection<Produit> listerProduits();
        Produit afficherProduit(int ProduitId);
        //Utilisateur modifierUtilisateur(Utilisateur u);
        ICollection<Utilisateur> listerAdministrateur();
        ICollection<Utilisateur> rechercherUtilisateurByName(string name);
        Utilisateur rechercherUtilisateurById(int utilisateurId);
        ICollection<Client> listerClient();
        ICollection<Client> rechercherClientByName(string name);
        void changerEtatClient(int idClient);
        void desactiverMonCompte(int idClient);
        Catalogue ajouterCatalogue(Catalogue c);
       
        void supprimerCatalogue(int CatalogueId);
        Catalogue afficherCatalogue(int CatalogueId);
        ICollection<Catalogue> listerCatalogue();

        ICollection<Produit> rechercherProduitById(int id);
        ICollection<Produit> rechercherProduitsByName(string Nom);
        ICollection<Produit> rechercherProduits(decimal PrixMin, decimal PrixMax);
        ICollection<Produit> rechercherProduitsByCategorie(string Categorie);

        Promotion creerPromotion(Promotion p);
        void supprimerPromotion(int PromotionId);
        Promotion modifierPromotion(Promotion p);
        Promotion afficherPromotion(int PromotionId);
        ICollection<Promotion> listerPromotions();
        ICollection<PromotionProduit> afficherPromotionProduit();

        Avis_ClientProduit ajouterAvis(Avis_ClientProduit comm);
        Avis_ClientProduit afficherAvis(int UtilisateurId, int ProduitId);
        Avis_ClientProduit modifierAvis(Avis_ClientProduit comm);
        void supprimerAvis(int UtilisateurId, int ProduitId);
        ICollection<ProduitClientAvisModel> listerAvisProduit(int ProduitId);
        Avis_ClientProduit trouverAvis(int UtilisateurId, int ProduitId);

        

        Adresse ajouterAdresse(Adresse a);
        void supprimerAdresse(int AdresseId);
        Adresse afficherAdresse(int AdresseId);
        Adresse modifierAdresse(Adresse a);
        ICollection<Adresse> listerAdresse(int UtilisateurId);
        

        Abonnement creerAbonnement(Abonnement a);
        void supprimerAbonnement(int AbonnementId);
        Abonnement afficherAbonnement(int AbonnementId);
        Abonnement modifierAbonnement(Abonnement a);
        ICollection<Abonnement> listerAbonnement(int UtilisateurId);       //pour un client particulier
        ICollection<Abonnement> listerTousAbonnements();
        AbonnementClient ajouterAbonnementClient(AbonnementClient ac);
        void supprimerAbonnementClient(int AbonnementId, int UtilisateurId);
        

        Role ajouterRole(Role r);
        ICollection<Role> listerRoles();

        AdresseClient ajouterAdresseClient(int AdresseId, int UtilisateurId);
        ICollection<AdresseClientModel> listerAdresseClient();

        ProduitCommande ajouterLigneDeCommande(ProduitCommande p);
        void supprimerLigneDeCommande(int ProduitId, int PanierId);
        void modifierLigneCommande(ProduitCommande p);

        Panier ajouterPanier(Panier p);
        void supprimerPanier(int PanierId);
        Panier findPanier(int PanierId);
        ICollection<ProduitCommande> afficheLigneDeCommande();

        ICollection<ProduitCatalogueModel> listerProduitCatalogue();
        Anniversaire ajouterAnniversaire(Anniversaire a);
        ICollection<Anniversaire> listerAnniversaires();
        void supprimerAnniversaire(int AnniversaireId);
        Anniversaire modifierAnniversaire(Anniversaire a);
        Anniversaire afficherAnniversaire(int AnniversaireId);

        decimal AttributionAnniversaire(ModelAnnivClient ac, AnniversaireClient a);
        decimal UtilisationAnniversaire(ModelAnnivClient ac, AnniversaireClient a);

        Fidelite ajouterFidelite(Fidelite f);
        void supprimerFidelite(int FideliteId);
        Fidelite modifierFidelite(Fidelite f);
        Fidelite afficherFidelite(int FideliteId);
        ICollection<Fidelite> listerFidelite();

       
        
        CarteBancaire ajouterCarteBancaire(CarteBancaire cb);
        Cheque ajouterCheque(Cheque c);
        Virement ajouterVirement(Virement v);
        Facture ajouterFacture(Facture f);
        void supprimerMoyenPaiement(int MoyenPaiementId);
        ICollection<CarteBancaire> listerCarteBancaire(int id);
        ICollection<CommandeMoyenPaiementModel> afficherCommandeMoyenPaiement(int id);

        //ICollection<ModelCreationPdfFacture> afficherModelCreationPdfFacture(int CommandeId);
        void creationFacturePDF(int CommandeId);

        Historique_UtilisateurProduit ajouterHistorique_UtilisateurProduit(Historique_UtilisateurProduit h);
        ICollection<Historique_UtilisateurProduitModel> afficherHistorique_UtilisateurProduit(int UtilisateurId);
        
        //fonctionnalite catalogue ajout le 12/10/2016 a 14h00
        Catalogue findCatalogue(int id);
        void modifierCatalogue(Catalogue uncatalogue);

        ICollection<Catalogue> findAllCatalogue();

        Promotion ajouterPromotion(Promotion p);
        Promotion findPromotionbyId(int id);
        ICollection<Promotion> findAllPromotion();
        ICollection<Promotion> getProduitIdPromo(string nameProduit);
        ICollection<Panier> findAllPanier();


    }
}
