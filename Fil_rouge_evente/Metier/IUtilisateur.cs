using Fil_rouge_evente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fil_rouge_evente.Metier
{
    public interface IUtilisateur
    {
        Utilisateur afficherCompte(int UtilisateurId);
        ICollection<Produit> listerProduits();
        ICollection<ProduitCatalogueModel> listerProduitCatalogue();
        Produit afficherProduit(int ProduitId);
        ICollection<Produit> rechercherProduitsByName(string Nom);
        Utilisateur connexionCompte(Utilisateur ut);
        ICollection<PromotionProduit> afficherPromotionProduit();
        Anniversaire afficherAnniversaire(int AnniversaireId);
        Fidelite afficherFidelite(int FideliteId);

        ICollection<Produit> rechercherProduits(int PrixMin, int PrixMax);
        ICollection<Produit> rechercherProduitsByCategorie(string Categorie);
        Historique_UtilisateurProduit ajouterHistorique_UtilisateurProduit(Historique_UtilisateurProduit h);
        ICollection<Historique_UtilisateurProduitModel> afficherHistorique_UtilisateurProduit(int UtilisteurId);

        ICollection<ProduitClientAvisModel> listerAvisProduit(int ProduitId);

    }
}
