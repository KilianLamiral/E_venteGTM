using Fil_rouge_evente.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fil_rouge_evente.Models;

namespace Fil_rouge_evente.Metier
{
    public class ClientImpl: IClient
    {
        IDAO idao = new DAOImpl();
        public ICollection<Produit> rechercherProduitsByName(string Nom)
        {
            return idao.rechercherProduitsByName(Nom);
        }

     

        public ICollection<Produit> rechercherProduits(int PrixMin, int PrixMax)
        {
            return idao.rechercherProduits(PrixMin, PrixMax);
        }

        public ICollection<Produit> rechercherProduitsByCategorie(string Categorie)
        {
            return idao.rechercherProduitsByCategorie(Categorie);
        }

        public Client creationCompteClient(ClientModel c)
        {

            return idao.creationCompteClient(c);
        }

        public Utilisateur afficherCompte(int UtilisateurId)
        {
            return idao.afficherCompte(UtilisateurId);
        }

        public Commande creerCommande(Commande c)
        {
            return idao.creerCommande(c);
        }

        public Commande modifierCommande(Commande c)
        {
            return idao.modifierCommande(c);
        }

        public void supprimerCommande(int CommandeId)
        {
            idao.supprimerCommande(CommandeId);
        }

        public ICollection<Commande> listerCommandes(int UtilisateurId)
        {
            return idao.listerCommandes(UtilisateurId);
        }

        public Commande afficherCommande(int CommandeId)
        {
            return idao.afficherCommande(CommandeId);
        }

        public ICollection<Abonnement> listerTousAbonnements()
        {
            return idao.listerTousAbonnements();
        }

        public AbonnementClient ajouterAbonnementClient(AbonnementClient ac)
        {
            return idao.ajouterAbonnementClient(ac);
        }

        public ICollection<Abonnement> listerAbonnement(int UtilisateurId)
        {
            return idao.listerAbonnement(UtilisateurId);
        }

        public AdresseClient ajouterAdresseClient(int AdresseId, int UtilisateurId)
        {
            return idao.ajouterAdresseClient(AdresseId, UtilisateurId);
        }

        public ProduitCommande ajouterLigneDeCommande(ProduitCommande pc)
        {
            return idao.ajouterLigneDeCommande(pc);
        }

        public void supprimerLigneDeCommande(int ProduitId, int CommandeId)
        {
            idao.supprimerLigneDeCommande(ProduitId, CommandeId);
        }

        public void modifierLigneDeCommande(ProduitCommande pc)
        {
             idao.modifierLigneCommande(pc);
        }

        public Panier ajouterPanier(Panier p)
        {
            return idao.ajouterPanier(p);
        }

        public void supprimerPanier(int PanierId)
        {
            idao.supprimerPanier(PanierId);
        }

       

        public ICollection<Promotion> listerPromotions()
        {
            return idao.listerPromotions();
        }

        public Utilisateur connexionCompte(Utilisateur ut)
        {
            return idao.connexionCompte(ut);
        }

        public ICollection<Produit> listerProduits()
        {
            return idao.listerProduits();
        }

        public ICollection<ProduitCatalogueModel> listerProduitCatalogue()
        {
            return idao.listerProduitCatalogue();
        }

        public Produit afficherProduit(int ProduitId)
        {
            return idao.afficherProduit(ProduitId);
        }

        public Client modifierCompte(Client c)
        {
            return idao.modifierCompte(c);
        }

        public Adresse ajouterAdresse(Adresse a)
        {
            return idao.ajouterAdresse(a);
        }

        public void supprimerAdresse(int AdresseId)
        {
            idao.supprimerAdresse(AdresseId);
        }

        public ICollection<Adresse> listerAdresse(int UtilisateurId)
        {
            return idao.listerAdresse(UtilisateurId);
        }

        public ICollection<PromotionProduit> afficherPromotionProduit()
        {
            return idao.afficherPromotionProduit();
        }

        public Anniversaire afficherAnniversaire(int AnniversaireId)
        {
            return idao.afficherAnniversaire(AnniversaireId);
        }

        public Fidelite afficherFidelite(int FideliteId)
        {
            return idao.afficherFidelite(FideliteId);
        }
        
        public Adresse modifierAdresse(Adresse a)
        {
            return idao.modifierAdresse(a);
        }


        public Adresse afficherAdresse(int AdresseId)
        {
            return idao.afficherAdresse(AdresseId);
        }

        public CarteBancaire ajouterCarteBancaire(CarteBancaire cb)
        {
            return idao.ajouterCarteBancaire(cb);
        }

        public Cheque ajouterCheque(Cheque c)
        {
            return idao.ajouterCheque(c);
        }

        public Virement ajouterVirement(Virement v)
        {
            return idao.ajouterVirement(v);
        }

        public Facture ajouterFacture(Facture f)
        {
            return idao.ajouterFacture(f);
        }

        public void supprimerMoyenPaiement(int MoyenPaiementId)
        {
            idao.supprimerMoyenPaiement(MoyenPaiementId);
        }

        public ICollection<CommandeMoyenPaiementModel> afficherCommandeMoyenPaiement(int id)
        {
            return afficherCommandeMoyenPaiement(id);
        }

        public void desactiverMonCompte(int idClient)
        {
            idao.desactiverMonCompte(idClient);
        }
		
		 public decimal AttributionAnniversaire(ModelAnnivClient ac, AnniversaireClient a)
        {
            return idao.AttributionAnniversaire(ac, a);
        }
        public decimal UtilisationAnniversaire(ModelAnnivClient ac, AnniversaireClient a)
        {
            return idao.UtilisationAnniversaire(ac, a);
        }
        public ICollection<CarteBancaire> listerCarteBancaire(int id)
        {
            return idao.listerCarteBancaire(id);
        }

        //public ICollection<ModelCreationPdfFacture> afficherModelCreationPdfFacture(int CommandeId)
        //{
        //   // return idao.afficherModelCreationPdfFacture(CommandeId);
        //}

        public Historique_UtilisateurProduit ajouterHistorique_UtilisateurProduit(Historique_UtilisateurProduit h)
        {
            return idao.ajouterHistorique_UtilisateurProduit(h);
        }

        public ICollection<Historique_UtilisateurProduitModel> afficherHistorique_UtilisateurProduit(int UtilisateurId)
        {
            return idao.afficherHistorique_UtilisateurProduit(UtilisateurId);
        }
		
		   public ICollection<ProduitCommande> afficheLigneDeCommande()
        {
            return idao.afficheLigneDeCommande();
        }

        public ICollection<Panier> findAllPanier()
        {
            return idao.findAllPanier();
        }

        public Panier findPanier(int PanierId)
        {
            return idao.findPanier(PanierId);
        }
		
		public Avis_ClientProduit ajouterAvis(Avis_ClientProduit comm)
        {
            return idao.ajouterAvis(comm);
        }


        public ICollection<ProduitClientAvisModel> listerAvisProduit(int ProduitId)
        {
            return idao.listerAvisProduit(ProduitId);
        }


        public Avis_ClientProduit trouverAvis(int UtilisateurId, int ProduitId)
        {
            return idao.trouverAvis(UtilisateurId, ProduitId);
        }
    }
}