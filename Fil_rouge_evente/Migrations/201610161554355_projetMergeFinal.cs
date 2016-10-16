namespace Fil_rouge_evente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projetMergeFinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbonnementClients",
                c => new
                    {
                        AbonnementId = c.Int(nullable: false),
                        UtilisateurId = c.Int(nullable: false),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.AbonnementId, t.UtilisateurId })
                .ForeignKey("dbo.Abonnements", t => t.AbonnementId, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurId, cascadeDelete: true)
                .Index(t => t.AbonnementId)
                .Index(t => t.UtilisateurId);
            
            CreateTable(
                "dbo.Abonnements",
                c => new
                    {
                        AbonnementId = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Duree = c.Int(nullable: false),
                        Prix = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.AbonnementId);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        UtilisateurId = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50, unicode: false),
                        Prenom = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        Actif = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                        DateNaissance = c.DateTime(),
                        NumeroCarteFidelite = c.Int(),
                        NombrePoints = c.Int(),
                        CompteASupprimer = c.Boolean(),
                        civilite = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UtilisateurId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.Email, unique: true, name: "EmailIndex")
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Avis_ClientProduit",
                c => new
                    {
                        UtilisateurId = c.Int(nullable: false),
                        ProduitId = c.Int(nullable: false),
                        Note = c.Single(nullable: false),
                        Commentaire = c.String(),
                    })
                .PrimaryKey(t => new { t.UtilisateurId, t.ProduitId })
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurId, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .Index(t => t.UtilisateurId)
                .Index(t => t.ProduitId);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        ProduitId = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        CategorieId = c.Int(nullable: false),
                        Prix = c.Decimal(nullable: false, storeType: "money"),
                        Stock = c.Int(nullable: false),
                        Path = c.String(nullable: false),
                        CatalogueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProduitId)
                .ForeignKey("dbo.Catalogues", t => t.CatalogueId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategorieId, cascadeDelete: true)
                .Index(t => t.CategorieId)
                .Index(t => t.CatalogueId);
            
            CreateTable(
                "dbo.Catalogues",
                c => new
                    {
                        CatalogueId = c.Int(nullable: false, identity: true),
                        NomCatalogue = c.String(),
                    })
                .PrimaryKey(t => t.CatalogueId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieId = c.Int(nullable: false, identity: true),
                        NomCategorie = c.String(),
                    })
                .PrimaryKey(t => t.CategorieId);
            
            CreateTable(
                "dbo.Historique_UtilisateurProduit",
                c => new
                    {
                        UtilisateurId = c.Int(nullable: false),
                        ProduitId = c.Int(nullable: false),
                        DateConsultation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UtilisateurId, t.ProduitId })
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurId, cascadeDelete: true)
                .Index(t => t.UtilisateurId)
                .Index(t => t.ProduitId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Droit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.ProduitCommandes",
                c => new
                    {
                        ProduitId = c.Int(nullable: false),
                        PanierId = c.Int(nullable: false),
                        quantite = c.Int(nullable: false),
                        commande_CommandeId = c.Int(),
                    })
                .PrimaryKey(t => new { t.ProduitId, t.PanierId })
                .ForeignKey("dbo.Commandes", t => t.commande_CommandeId)
                .ForeignKey("dbo.Paniers", t => t.PanierId, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .Index(t => t.ProduitId)
                .Index(t => t.PanierId)
                .Index(t => t.commande_CommandeId);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        CommandeId = c.Int(nullable: false, identity: true),
                        Commentaire = c.String(),
                        DateCommande = c.DateTime(nullable: false),
                        UtilisateurId = c.Int(nullable: false),
                        StatutCommandeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommandeId)
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurId, cascadeDelete: true)
                .ForeignKey("dbo.StatutCommandes", t => t.StatutCommandeId, cascadeDelete: true)
                .Index(t => t.UtilisateurId)
                .Index(t => t.StatutCommandeId);
            
            CreateTable(
                "dbo.StatutCommandes",
                c => new
                    {
                        StatutCommandeId = c.Int(nullable: false, identity: true),
                        typeCommande = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatutCommandeId);
            
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        PanierId = c.Int(nullable: false, identity: true),
                        NombreProduits = c.Int(nullable: false),
                        Prixtotal = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.PanierId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        NomPromotion = c.String(),
                        Remise = c.Int(nullable: false),
                        ProduitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .Index(t => t.ProduitId);
            
            CreateTable(
                "dbo.AdresseClients",
                c => new
                    {
                        AdresseId = c.Int(nullable: false),
                        UtilisateurId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AdresseId, t.UtilisateurId })
                .ForeignKey("dbo.Adresses", t => t.AdresseId, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurId, cascadeDelete: true)
                .Index(t => t.AdresseId)
                .Index(t => t.UtilisateurId);
            
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdresseId = c.Int(nullable: false, identity: true),
                        NumeroRue = c.String(),
                        NomRue = c.String(),
                        CodePostal = c.String(),
                        Ville = c.String(),
                        Pays = c.String(),
                        typeadresse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdresseId);
            
            CreateTable(
                "dbo.AnniversaireClients",
                c => new
                    {
                        AnniversaireId = c.Int(nullable: false),
                        UtilisateurId = c.Int(nullable: false),
                        Actif = c.Boolean(nullable: false),
                        Utilise = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnniversaireId, t.UtilisateurId })
                .ForeignKey("dbo.Anniversaires", t => t.AnniversaireId, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurId, cascadeDelete: true)
                .Index(t => t.AnniversaireId)
                .Index(t => t.UtilisateurId);
            
            CreateTable(
                "dbo.Anniversaires",
                c => new
                    {
                        AnniversaireId = c.Int(nullable: false, identity: true),
                        montant = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AnniversaireId);
            
            CreateTable(
                "dbo.FideliteClients",
                c => new
                    {
                        FideliteId = c.Int(nullable: false),
                        UtilisateurId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FideliteId, t.UtilisateurId })
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurId, cascadeDelete: true)
                .ForeignKey("dbo.Fidelites", t => t.FideliteId, cascadeDelete: true)
                .Index(t => t.FideliteId)
                .Index(t => t.UtilisateurId);
            
            CreateTable(
                "dbo.Fidelites",
                c => new
                    {
                        FideliteId = c.Int(nullable: false, identity: true),
                        NombrePoints = c.Int(nullable: false),
                        Avantages = c.String(),
                    })
                .PrimaryKey(t => t.FideliteId);
            
            CreateTable(
                "dbo.MoyenPaiements",
                c => new
                    {
                        MoyenPaiementId = c.Int(nullable: false, identity: true),
                        Actif = c.Boolean(nullable: false),
                        TypePaiement = c.Int(nullable: false),
                        UtilisateurId = c.Int(nullable: false),
                        NomProprietaire = c.String(),
                        NumeroCarte = c.String(maxLength: 16),
                        Mois = c.Int(),
                        Annee = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MoyenPaiementId)
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurId, cascadeDelete: true)
                .Index(t => t.UtilisateurId);
            
            CreateTable(
                "dbo.CommandeProduits",
                c => new
                    {
                        CommandeId = c.Int(nullable: false),
                        ProduitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CommandeId, t.ProduitId })
                .ForeignKey("dbo.Commandes", t => t.CommandeId, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .Index(t => t.CommandeId)
                .Index(t => t.ProduitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommandeProduits", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.CommandeProduits", "CommandeId", "dbo.Commandes");
            DropForeignKey("dbo.MoyenPaiements", "UtilisateurId", "dbo.Utilisateurs");
            DropForeignKey("dbo.FideliteClients", "FideliteId", "dbo.Fidelites");
            DropForeignKey("dbo.FideliteClients", "UtilisateurId", "dbo.Utilisateurs");
            DropForeignKey("dbo.AnniversaireClients", "UtilisateurId", "dbo.Utilisateurs");
            DropForeignKey("dbo.AnniversaireClients", "AnniversaireId", "dbo.Anniversaires");
            DropForeignKey("dbo.AdresseClients", "UtilisateurId", "dbo.Utilisateurs");
            DropForeignKey("dbo.AdresseClients", "AdresseId", "dbo.Adresses");
            DropForeignKey("dbo.AbonnementClients", "UtilisateurId", "dbo.Utilisateurs");
            DropForeignKey("dbo.Promotions", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.ProduitCommandes", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.ProduitCommandes", "PanierId", "dbo.Paniers");
            DropForeignKey("dbo.Commandes", "StatutCommandeId", "dbo.StatutCommandes");
            DropForeignKey("dbo.ProduitCommandes", "commande_CommandeId", "dbo.Commandes");
            DropForeignKey("dbo.Commandes", "UtilisateurId", "dbo.Utilisateurs");
            DropForeignKey("dbo.Utilisateurs", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Historique_UtilisateurProduit", "UtilisateurId", "dbo.Utilisateurs");
            DropForeignKey("dbo.Historique_UtilisateurProduit", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.Produits", "CategorieId", "dbo.Categories");
            DropForeignKey("dbo.Produits", "CatalogueId", "dbo.Catalogues");
            DropForeignKey("dbo.Avis_ClientProduit", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.Avis_ClientProduit", "UtilisateurId", "dbo.Utilisateurs");
            DropForeignKey("dbo.AbonnementClients", "AbonnementId", "dbo.Abonnements");
            DropIndex("dbo.CommandeProduits", new[] { "ProduitId" });
            DropIndex("dbo.CommandeProduits", new[] { "CommandeId" });
            DropIndex("dbo.MoyenPaiements", new[] { "UtilisateurId" });
            DropIndex("dbo.FideliteClients", new[] { "UtilisateurId" });
            DropIndex("dbo.FideliteClients", new[] { "FideliteId" });
            DropIndex("dbo.AnniversaireClients", new[] { "UtilisateurId" });
            DropIndex("dbo.AnniversaireClients", new[] { "AnniversaireId" });
            DropIndex("dbo.AdresseClients", new[] { "UtilisateurId" });
            DropIndex("dbo.AdresseClients", new[] { "AdresseId" });
            DropIndex("dbo.Promotions", new[] { "ProduitId" });
            DropIndex("dbo.Commandes", new[] { "StatutCommandeId" });
            DropIndex("dbo.Commandes", new[] { "UtilisateurId" });
            DropIndex("dbo.ProduitCommandes", new[] { "commande_CommandeId" });
            DropIndex("dbo.ProduitCommandes", new[] { "PanierId" });
            DropIndex("dbo.ProduitCommandes", new[] { "ProduitId" });
            DropIndex("dbo.Historique_UtilisateurProduit", new[] { "ProduitId" });
            DropIndex("dbo.Historique_UtilisateurProduit", new[] { "UtilisateurId" });
            DropIndex("dbo.Produits", new[] { "CatalogueId" });
            DropIndex("dbo.Produits", new[] { "CategorieId" });
            DropIndex("dbo.Avis_ClientProduit", new[] { "ProduitId" });
            DropIndex("dbo.Avis_ClientProduit", new[] { "UtilisateurId" });
            DropIndex("dbo.Utilisateurs", new[] { "RoleId" });
            DropIndex("dbo.Utilisateurs", "EmailIndex");
            DropIndex("dbo.AbonnementClients", new[] { "UtilisateurId" });
            DropIndex("dbo.AbonnementClients", new[] { "AbonnementId" });
            DropTable("dbo.CommandeProduits");
            DropTable("dbo.MoyenPaiements");
            DropTable("dbo.Fidelites");
            DropTable("dbo.FideliteClients");
            DropTable("dbo.Anniversaires");
            DropTable("dbo.AnniversaireClients");
            DropTable("dbo.Adresses");
            DropTable("dbo.AdresseClients");
            DropTable("dbo.Promotions");
            DropTable("dbo.Paniers");
            DropTable("dbo.StatutCommandes");
            DropTable("dbo.Commandes");
            DropTable("dbo.ProduitCommandes");
            DropTable("dbo.Roles");
            DropTable("dbo.Historique_UtilisateurProduit");
            DropTable("dbo.Categories");
            DropTable("dbo.Catalogues");
            DropTable("dbo.Produits");
            DropTable("dbo.Avis_ClientProduit");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Abonnements");
            DropTable("dbo.AbonnementClients");
        }
    }
}
