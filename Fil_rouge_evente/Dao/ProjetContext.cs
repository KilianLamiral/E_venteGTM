using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Dao
{
    public class ProjetContext: DbContext
    {
        public ProjetContext():base("Projet")          //Pour définir le nom de la BDD
        {

        }
        public DbSet<Abonnement> abonnements { get; set; }
        public DbSet<AbonnementClient> abonnementClients { get; set; }
        public DbSet<Adresse> adresses { get; set; }
        public DbSet<AdresseClient> adresseClients { get; set; }
        public DbSet<Anniversaire> anniversaires { get; set; }
        public DbSet<AnniversaireClient> anniversaireClients { get; set; }
        public DbSet<Avis_ClientProduit> avis_clientProduits { get; set; }
        public DbSet<Catalogue> catalogues { get; set; }
        public DbSet<Commande> commandes { get; set; }
        public DbSet<CommandeProduit> commandeProduits { get; set; }
        public DbSet<Fidelite> fidelites { get; set; }
        public DbSet<FideliteClient> fideliteClients { get; set; }
        public DbSet<Historique_UtilisateurProduit> historique_utilisateurProduits { get; set; }
        public DbSet<MoyenPaiement> moyenPaiements { get; set; }
        public DbSet<Panier> paniers { get; set; }
        public DbSet<Produit> produits { get; set; }
        public DbSet<ProduitCommande> produitCommandes { get; set; }
        public DbSet<Promotion> promotions { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<StatutCommande> statutCommandes { get; set; }
        public DbSet<Utilisateur> utilisateurs { get; set; }

        public DbSet<Client> clients { get; set; }
        public DbSet<CarteBancaire> carteBancaires { get; set; }
        public DbSet<Cheque> cheques { get; set; }
        public DbSet<Facture> factures { get; set; }
        public DbSet<Virement> virements { get; set; }
    }
}