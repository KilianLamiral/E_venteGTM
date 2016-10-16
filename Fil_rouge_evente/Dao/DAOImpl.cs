using Fil_rouge_evente.Metier;
using Fil_rouge_evente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static Fil_rouge_evente.Metier.Client;
using static Fil_rouge_evente.Metier.MoyenPaiement;

namespace Fil_rouge_evente.Dao
{
    public class DAOImpl: IDAO
    {
        public Client creationCompteClient(ClientModel monclient)
        {
            using (var db = new Dao.ProjetContext())
            {

                //ajout de l'adresse rentrée par l'utilisateur (client)

                Adresse adrClient = new Adresse();
                adrClient.NomRue = monclient.NomDeRue;
                adrClient.NumeroRue = monclient.NumeroRue;
                adrClient.CodePostal = monclient.CodePostal;
                adrClient.Ville = monclient.Ville;
                adrClient.Pays = monclient.Pays;

                switch (monclient.typeadresse)
                {
                    case ClientModel.TypeAdresse.Livraison:
                        adrClient.typeadresse = Adresse.TypeAdresse.Livraison;
                        break;
                    case ClientModel.TypeAdresse.Facturation:
                        adrClient.typeadresse = Adresse.TypeAdresse.Facturation;
                        break;
                    default:
                        break;
                }

                db.adresses.Add(adrClient);
                db.SaveChanges();
                //ajout du role attribué  a l'utilisateur (client) par l admin
               

                //db.roles.Add(r);
                //db.SaveChanges();



                Client c = new Client();
                c.clientAdresses = adrClient.adresseClients;
                switch (monclient.civilite)
                {
                    case ClientModel.Civilite.Mademoiselle:
                        c.civilite = Civilite.Mademoiselle;
                        break;
                    case ClientModel.Civilite.Madame:
                        c.civilite = Civilite.Madame;
                        break;
                    case ClientModel.Civilite.Monsieur:
                        c.civilite = Civilite.Monsieur;
                        break;
                    default:
                        break;
                }
                monclient.CompteActif = true;
                monclient.CompteASupprimer = false;
                c.Actif = monclient.CompteActif;
                c.CompteASupprimer = monclient.CompteASupprimer;
                c.confirmPassword = monclient.confirmPassword;
                c.DateNaissance = monclient.DateNaissance;
                c.Email = monclient.Email;
                c.Nom = monclient.Nom;
                c.NombrePoints = monclient.NombrePoints;
                c.NumeroCarteFidelite = monclient.NumeroCarteFidelite;
                c.password = monclient.password;
                c.Prenom = monclient.Prenom;
				c.RoleId = 1;  // role utilisateur 
			

                db.utilisateurs.Add(c);

                db.SaveChanges();
                return c;
            }
        }

        

        public Administrateur creationCompteAdmin(Administrateur a)
        {
            using (var db = new Dao.ProjetContext())
            {
               
                
                db.SaveChanges();

                a.RoleId = 2;

                a.Actif = true;

                db.utilisateurs.Add(a);
                db.SaveChanges();
                return a;
            }
        }

        public void suppressionCompte(int UtilisateurId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = db.utilisateurs.Find(UtilisateurId);
                db.utilisateurs.Remove(res);
                db.SaveChanges();
            }
        }

        public Utilisateur afficherCompte(int UtilisateurId)
        {
            using (var db = new Dao.ProjetContext())
            {
                return db.utilisateurs.Find(UtilisateurId);
            }
        }

        public Commande creerCommande(Commande c)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.commandes.Add(c);
                db.SaveChanges();
                return c;
            }
        }

        public void supprimerCommande(int CommandeId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = db.commandes.Find(CommandeId);
                db.commandes.Remove(res);
                db.SaveChanges();
            }
        }

        public Produit ajouterProduit(Produit p)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.produits.Add(p);
               

                db.SaveChanges();

                Panier pan = new Panier();
                pan.NombreProduits = 0;
                pan.PrixTotal = 0;

                db.paniers.Add(pan);
                db.SaveChanges();


                ProduitCommande pc = new ProduitCommande();

                pc.PanierId = pan.PanierId;
                pc.ProduitId = p.ProduitId;
                pc.quantite = 20;

                db.produitCommandes.Add(pc);
                db.SaveChanges();

                return p;
            }
        }

        public void supprimerProduit(int ProduitId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = db.produits.Find(ProduitId);
                db.produits.Remove(res);
                db.SaveChanges();
            }
        }

        public Catalogue ajouterCatalogue(Catalogue c)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.catalogues.Add(c);
                db.SaveChanges();
                return c;
            }
        }

        public void modifierCatalogue(Catalogue c)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
               
            }
        }

        public void supprimerCatalogue(int CatalogueId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = db.catalogues.Find(CatalogueId);
                db.catalogues.Remove(res);
                db.SaveChanges();
            }
        }

        public Catalogue afficherCatalogue(int CatalogueId)
        {
            using (var db = new Dao.ProjetContext())
            {
                return db.catalogues.Find(CatalogueId);
            }
        }

        public ICollection<Produit> rechercherProduitsByName(string Nom)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = from p in db.produits
                          where p.Nom.Contains(Nom)
                          select p;

                return res.ToList();
            }
        }

        public ICollection<Produit> rechercherProduits(decimal prixMin, decimal prixMax)
        {
            using (var db = new Dao.ProjetContext())
            {
                if (prixMin < prixMax)
                {
                    var res = from p in db.produits
                              where p.Prix >= prixMin && p.Prix <= prixMax
                              select p;

                    if (res.Count() != 0)
                    {
                        return res.ToList();

                    }
                    else
                    {
                        return listerProduits();
                    }
                }
                else
                {
                    
                    return listerProduits() ;
                }






            }
        }

        public ICollection<Produit> rechercherProduitsByCategorie(string Categorie)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = from p in db.produits
                          where p.Categorie.Contains(Categorie)
                          select p;
                return res.ToList();
            }
        }

        public Promotion creerPromotion(Promotion p)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.promotions.Add(p);
                db.SaveChanges();
                return p;
            }
        }

        public void supprimerPromotion(int PromotionId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = db.promotions.Find(PromotionId);
                db.promotions.Remove(res);
                db.SaveChanges();
            }
        }

        public Avis_ClientProduit ajouterAvis(Avis_ClientProduit comm)
        {
            using(var db = new Dao.ProjetContext())
            {
                db.avis_clientProduits.Add(comm);
                db.SaveChanges();
                return comm;
            }
        }

        public Adresse ajouterAdresse(Adresse a)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.adresses.Add(a);
                db.SaveChanges();
                return a;
            }
        }

        public void supprimerAdresse(int AdresseId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = db.adresses.Find(AdresseId);
                db.adresses.Remove(res);
                db.SaveChanges();
            }
        }

        public Abonnement ajouterAbonnement(Abonnement a)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.abonnements.Add(a);
                db.SaveChanges();
                return a;
            }
        }

        public void supprimerAbonnement(int AbonnementId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = db.abonnements.Find(AbonnementId);
                db.abonnements.Remove(res);
                db.SaveChanges();
            }
        }

        public Role ajouterRole(Role r)
        {
            using (var db = new Dao.ProjetContext())
            {
			    Role rclient =new Role();
				
                db.roles.Add(r);
                db.SaveChanges();
				
				db.roles.Add(rclient);
                db.SaveChanges();
				
                return r;
            }
        }

        public AdresseClient ajouterAdresseClient(int AdresseId, int UtilisateurId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var a = new AdresseClient();
                a.AdresseId = AdresseId;
                a.UtilisateurId = UtilisateurId;
                db.adresseClients.Add(a);
                db.SaveChanges();
                return a;
            }
        }

        public ICollection<Commande> listerCommandes(int UtilisateurId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = from c in db.commandes
                          where c.UtilisateurId == UtilisateurId
                          select c;
                return res.ToList();

            }
        }

        public Adresse afficherAdresse(int AdresseId)
        {
            using (var db = new Dao.ProjetContext())
            {
                return db.adresses.Find(AdresseId);
            }
        }

        public Adresse modifierAdresse(Adresse a)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return a;
            }
        }

        public Client modifierCompte(Client c)
        {
            using (var db = new Dao.ProjetContext())
            {
                
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return c;
            }
        }

        public Commande modifierCommande(Commande c)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return c;
            }
        }

        public Produit modifierProduit(Produit p)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return p;
            }
        }

        public ICollection<Produit> listerProduits()
        {
            using (var db = new Dao.ProjetContext())
            {
                return db.produits.ToList();
            }
        }

        public Produit afficherProduit(int ProduitId)
        {
            using (var db = new Dao.ProjetContext())
            {
                return db.produits.Find(ProduitId);
            }
        }
     
        //public Utilisateur modifierUtilisateur(Utilisateur u)
        //{
        //    using (var db = new Dao.ProjetContext())
        //    {
        //        db.Entry(u).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return u;
        //    }
        //}

        public ICollection<Utilisateur> rechercherUtilisateurByName(string name)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = from u in db.utilisateurs
                          where u.Nom.Contains(name)
                          select u;

                return res.ToList();
            }
        }

        public Utilisateur rechercherUtilisateurById(int UtilisateurId)
        {
            using (var db = new Dao.ProjetContext())
            {
                return db.utilisateurs.Find(UtilisateurId);
            }
        }

        public ICollection<Client> listerClient()
        {
            using (var db = new Dao.ProjetContext())
            {
                return db.clients.ToList();
            }
        }

        public ICollection<Client> rechercherClientByName(string name)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = from u in db.clients
                          where u.Nom.Contains(name)
                          select u;

                return res.ToList();
            }
        }

        public void changerEtatClient(int idClient)
        {
            using (var db = new Dao.ProjetContext())
            {
                Client c = db.clients.Find(idClient);
                if (c.Actif == false)
                {
                    db.Entry(c).Entity.Actif = true;
                }
                else
                {
                    db.Entry(c).Entity.Actif = false;
                }
                db.SaveChanges();
            }
        }

        public void desactiverMonCompte(int idClient)
        {
            using (var db = new Dao.ProjetContext())
            {
                Client c = db.clients.Find(idClient);
                c.CompteASupprimer = true;
                db.SaveChanges();
            }
        }

        public ICollection<Utilisateur> listerAdministrateur()
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = from c in db.utilisateurs
                          where c.RoleId == 1
                          select c;

                return res.ToList();
            }
        }
        

        public Promotion modifierPromotion(Promotion p)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return p;
            }
        }

        public ProduitCommande ajouterLigneDeCommande(ProduitCommande p)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.produitCommandes.Add(p);
                db.SaveChanges();
                return p;
            }
        }

        public void supprimerLigneDeCommande(int ProduitId, int PanierId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = db.produitCommandes.Find(ProduitId, PanierId);
                db.produitCommandes.Remove(res);
                db.SaveChanges();
            }
        }

        public void modifierLigneCommande(ProduitCommande p)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                
            }
        }

        public Panier ajouterPanier(Panier p)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.paniers.Add(p);
                db.SaveChanges();
                return p;
            }
        }

        public void supprimerPanier(int PanierId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = db.paniers.Find(PanierId);
                db.paniers.Remove(res);
                db.SaveChanges();
            }
        }

        public Panier findPanier(int PanierId)
        {
            using (var db = new Dao.ProjetContext())
            {
                return db.paniers.Find(PanierId);
            }
        }
        

        //Peut-être nécessité de faire un model pour afficher également le login du client
        public Avis_ClientProduit afficherAvis(int UtilisateurId, int ProduitId)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = from dp in db.avis_clientProduits
                          where dp.UtilisateurId == UtilisateurId && dp.ProduitId == ProduitId
                          select dp;

                return res.ToList()[0];
            }
        }

        public void supprimerAvis(int UtilisateurId, int ProduitId)
        {
            using (var db = new ProjetContext())
            {
                var res = db.avis_clientProduits.Find(UtilisateurId, ProduitId);
                db.avis_clientProduits.Remove(res);
                db.SaveChanges();
            }
        }

        public Abonnement creerAbonnement(Abonnement a)
        {
            using (var db = new Dao.ProjetContext())
            {
                
                
                    db.abonnements.Add(a);
                    db.SaveChanges();
                    return a;
                
            }
        }

        public Abonnement afficherAbonnement(int AbonnementId)
        {
            using (var db = new Dao.ProjetContext())
            {
                return db.abonnements.Find(AbonnementId);
            }
        }

        public Commande afficherCommande(int CommandeId)
        {
            using (var db = new ProjetContext())
            {
                return db.commandes.Find(CommandeId);
            }
        }

        public Promotion afficherPromotion(int PromotionId)
        {
            using (var db = new ProjetContext())
            {
                return db.promotions.Find(PromotionId);
            }
        }

        public Avis_ClientProduit modifierAvis(Avis_ClientProduit comm)
        {
            using (var db = new ProjetContext())
            {
                db.Entry(comm).State = EntityState.Modified;
                db.SaveChanges();
                return comm;
            }
        }

        public ICollection<Adresse> listerAdresse(int UtilisateurId)
        {
            using (var db = new ProjetContext())
            {
                var res = from a in db.adresses
                          join ac in db.adresseClients on a.AdresseId equals ac.AdresseId
                          where ac.UtilisateurId == UtilisateurId
                          select a;

                return res.ToList();
            }
        }

        public ICollection<AdresseClientModel> listerAdresseClient()
        {
            using (var db = new ProjetContext())
            {
                var res = from ac in db.adresseClients
                          join a in db.adresses on ac.AdresseId equals a.AdresseId
                          join u in db.utilisateurs on ac.UtilisateurId equals u.UtilisateurId
                          select new AdresseClientModel
                          {
                              Nom = u.Nom,
                              Prenom = u.Prenom,
                              NumeroRue = a.NumeroRue,
                              NomRue = a.NomRue,
                              CodePostal = a.CodePostal,
                              Ville = a.Ville
                          };

                return res.ToList();
            }
        }

        public ICollection<Abonnement> listerAbonnement(int UtilisateurId)
        {
            using (var db = new ProjetContext())
            {
                var res = from a in db.abonnements
                          join ac in db.abonnementClients on a.AbonnementId equals ac.AbonnementId
                          where ac.UtilisateurId == UtilisateurId
                          select a;

                return res.ToList();
            }
        }

        public AbonnementClient ajouterAbonnementClient(AbonnementClient ac)
        {
            using (var db = new ProjetContext())
            {
                db.abonnementClients.Add(ac);
                db.SaveChanges();
                return ac;
            }
        }

        public ICollection<Abonnement> listerTousAbonnements()
        {
            using (var db = new ProjetContext())
            {
                return db.abonnements.ToList();
            }
        }

        public void supprimerAbonnementClient(int AbonnementId, int UtilisateurId)
        {
            using (var db = new ProjetContext())
            {
                var res = db.abonnementClients.Find(AbonnementId, UtilisateurId);
                db.abonnementClients.Remove(res);
                db.SaveChanges();
            }
        }

        public ICollection<Promotion> listerPromotions()
        {
            using (var db = new ProjetContext())
            {
               
                return db.promotions.ToList();
            }
        }

        public Utilisateur connexionCompte(Utilisateur ut)
        {

            using (var db = new ProjetContext())
            {
                var usr = from u in db.utilisateurs
                          where u.Email == ut.Email && u.password == ut.password & u.Actif == true
                          select u;

                return usr.FirstOrDefault();
            }
        }

        public ICollection<Catalogue> listerCatalogue()
        {
            using (var db = new ProjetContext())
            {
                return db.catalogues.ToList();
            }
        }

        public ICollection<ProduitCatalogueModel> listerProduitCatalogue()
        {
            using (var db = new ProjetContext())
            {
                var req = from p in db.produits
                          join c in db.catalogues on p.CatalogueId equals c.CatalogueId
                          select new ProduitCatalogueModel
                          {
                              ProduitId = p.ProduitId,
                              Nom = p.Nom,
                              Prix = p.Prix,
                              Stock = p.Stock,
                              Categorie = p.Categorie,
                              NomCatalogue = c.NomCatalogue,
                              Path = p.Path
                          };
                return req.ToList();
            }
        }
                          
        

        public ICollection<Produit> rechercherProduitById(int id)
        {
            using (var db = new ProjetContext())
            {
                var res = from p in db.produits
                          where p.ProduitId == id
                          select p;
                return res.ToList();
            }
        }

        public ICollection<Role> listerRoles()
        {
            using (var db = new ProjetContext())
            {
                return db.roles.ToList();
            }
        }

        public ICollection<Utilisateur> listerComptes()
        {
            using (var db = new ProjetContext())
            {
                return db.utilisateurs.ToList();
            }
        }

        public Abonnement modifierAbonnement(Abonnement a)
        {
            using (var db = new ProjetContext())
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return a;
            }
        }

        public ICollection<PromotionProduit> afficherPromotionProduit()
        {
            using (var db = new ProjetContext())
            {
                var res = from p1 in db.promotions
                          join p2 in db.produits on p1.ProduitId equals p2.ProduitId
                          select new PromotionProduit
                          {  
                              PromotionProduitId=p1.PromotionId,  
                              NomPromotion=p1.NomPromotion,                          
                              Remise = p1.Remise,
                              ProduitId = p2.ProduitId,
                              ProduitNom = p2.Nom,
                              Prix = p2.Prix
                          };

                return res.ToList();
            }
        }

        public Administrateur modifierCompteAdmin(Administrateur a)
        {
            using (var db = new ProjetContext())
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return a;
            }
        }

        public Anniversaire ajouterAnniversaire(Anniversaire a)
        {
            using (var db = new ProjetContext())
            {
                db.anniversaires.Add(a);
                db.SaveChanges();
                return a;
            }
        }
        public decimal AttributionAnniversaire(ModelAnnivClient ac, AnniversaireClient a)
        {
            using (var db = new Dao.ProjetContext())
            {
                if (ac.DateNaissance.Day == DateTime.Today.Day && ac.DateNaissance.Month == DateTime.Today.Month)
                {
                    ac.montant = 10 / 100;
                    a.Utilise = false;

                }
                return ac.montant;

            }
        }

        public decimal UtilisationAnniversaire(ModelAnnivClient ac, AnniversaireClient a)
        {
            using (var db = new Dao.ProjetContext())
            {
                if (a.Utilise == false && ac.montant <= 1 && ac.montant > 0)
                {


                    var Reduc = (ac.PrixTotal * ac.montant);
                    var PrixPanier = ac.PrixTotal - Reduc;
                    a.Utilise = true;
                    return PrixPanier;

                }
                else
                {
                    var PrixPanier = ac.PrixTotal;
                    return PrixPanier;

                }

            }
        }



        public ICollection<Anniversaire> listerAnniversaires()
        {
            using (var db = new ProjetContext())
            {
                return db.anniversaires.ToList();
            }
        }

        public void supprimerAnniversaire(int AnniversaireId)
        {
            using (var db = new ProjetContext())
            {
                var res = db.anniversaires.Find(AnniversaireId);
                db.anniversaires.Remove(res);
                db.SaveChanges();
            }
        }

        public Anniversaire modifierAnniversaire(Anniversaire a)
        {
            using (var db = new ProjetContext())
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return a;
            }
        }

        public Anniversaire afficherAnniversaire(int AnniversaireId)
        {
            using (var db = new ProjetContext())
            {
                return db.anniversaires.Find(AnniversaireId);
            }
        }

        public Fidelite ajouterFidelite(Fidelite f)
        {
            using (var db = new ProjetContext())
            {
                db.fidelites.Add(f);
                db.SaveChanges();
                return f;
            }
        }

        public void supprimerFidelite(int FideliteId)
        {
            using (var db = new ProjetContext())
            {
                var res = db.fidelites.Find(FideliteId);
                db.fidelites.Remove(res);
                db.SaveChanges();
            }
        }

        public Fidelite modifierFidelite(Fidelite f)
        {
            using (var db = new ProjetContext())
            {
                db.Entry(f).State = EntityState.Modified;
                db.SaveChanges();
                return f;
            }
        }

        public Fidelite afficherFidelite(int FideliteId)
        {
            using (var db = new ProjetContext())
            {
                return db.fidelites.Find(FideliteId);
            }
        }

        public ICollection<Fidelite> listerFidelite()
        {
            using (var db = new ProjetContext())
            {
                return db.fidelites.ToList();
            }
        }
        public ICollection<Catalogue> findCatalogueById(int id)
        {
            using (var edb = new ProjetContext())
            {
                var req = from c in edb.catalogues
                          where c.CatalogueId == id
                          select c;
                return req.ToList();
            }
        }

       

        public void supprimerMoyenPaiement(int MoyenPaiementId)
        {
            using (var db = new ProjetContext())
            {
                var res = db.moyenPaiements.Find(MoyenPaiementId);
                res.Actif = false;
                db.SaveChanges();
            }
        }

        public CarteBancaire ajouterCarteBancaire(CarteBancaire cb)
        {
            using (var db = new ProjetContext())
            {
                db.carteBancaires.Add(cb);
                cb.TypePaiement = typePaiement.CarteBancaire;
                db.SaveChanges();
                return cb;
            }
        }




        public Cheque ajouterCheque(Cheque c)
        {
            using (var db = new ProjetContext())
            {
                db.cheques.Add(c);
                c.TypePaiement = typePaiement.Cheque ;
                db.SaveChanges();
                return c;
            }
        }

        public Virement ajouterVirement(Virement v)
        {
            using (var db = new ProjetContext())
            {
                db.virements.Add(v);
                v.TypePaiement = typePaiement.Virement;
                db.SaveChanges();
                return v;
            }
        }

        public Facture ajouterFacture(Facture f)
        {
            using (var db = new ProjetContext())
            {
                db.factures.Add(f);
                f.TypePaiement = typePaiement.Facture;
                db.SaveChanges();
                return f;
            }
        }

        public ICollection<CommandeMoyenPaiementModel> afficherCommandeMoyenPaiement(int id)
        {
            using (var db = new ProjetContext())
            {
                var res = from c in db.commandes
                          join u in db.utilisateurs on c.UtilisateurId equals u.UtilisateurId
                          join m in db.moyenPaiements on u.UtilisateurId equals m.UtilisateurId
                          where u.UtilisateurId == id
                          select new CommandeMoyenPaiementModel
                          {
                              TypePaiement = m.TypePaiement,
                              DateCommande = c.DateCommande
                          };

                return res.ToList();
            }
        }

        public ICollection<CarteBancaire> listerCarteBancaire(int id)
        {
            using (var db = new ProjetContext())
            {
                var res = from c in db.carteBancaires
                          join u in db.utilisateurs on c.UtilisateurId equals u.UtilisateurId
                          where u.UtilisateurId == id && c.Actif == true
                          select c;

                return res.ToList();
            }
        }

        //public ICollection<ModelCreationPdfFacture> afficherModelCreationPdfFacture(int CommandeId)
        //{
        //    using (var db = new ProjetContext())
        //    {
        //        var res = from c in db.clients
        //                  join ac in db.adresseClients on c.UtilisateurId equals ac.UtilisateurId
        //                  join a in db.adresses on ac.AdresseId equals a.AdresseId
        //                  join co in db.commandes on c.UtilisateurId equals co.UtilisateurId
        //                  join f in db.factures on c.UtilisateurId equals f.UtilisateurId
        //                  //join pc in db.produitCommandes on co.CommandeId equals pc.CommandeId
        //                  join p in db.paniers on pc.PanierId equals p.PanierId
        //                  join pr in db.produits on pc.ProduitId equals pr.ProduitId
        //                  where co.CommandeId == CommandeId
        //                  select new ModelCreationPdfFacture
        //                  {
        //                      ClientId = c.UtilisateurId,
        //                      NomClient = c.Nom,
        //                      PrenomClient = c.Prenom,
        //                      NumeroRueFacturation = a.NumeroRue,
        //                      NomRueFacturation = a.NomRue,
        //                      CodePostalFacturation = a.CodePostal,
        //                      VilleFacturation = a.Ville,
        //                      NumeroRueLivraison = a.NumeroRue,
        //                      NomRueLivraison = a.NomRue,
        //                      CodePostalLivraison = a.CodePostal,
        //                      VilleLivraison = a.Ville,
        //                      DateCommande = co.DateCommande,
        //                      DateEcheance = co.DateCommande.AddDays(30),
        //                      FactureId = f.MoyenPaiementId,
        //                      PrixTotalCommande = p.PrixTotal,
        //                      //PrixTotalProduit = pr.Prix * pc.quantite
        //                  };
        //        return res.ToList();
        //    }
        //}


        public void creationFacturePDF(int CommandeId)
        {
            throw new NotImplementedException();
        }

        public Historique_UtilisateurProduit ajouterHistorique_UtilisateurProduit(Historique_UtilisateurProduit h)
        {
            using (var db = new ProjetContext())
            {
                var res = from hup in db.historique_utilisateurProduits
                          where h.UtilisateurId == hup.UtilisateurId && h.ProduitId == hup.ProduitId
                          select hup;

                if (res.Count() == 0)
                {
                    db.historique_utilisateurProduits.Add(h);
                    db.SaveChanges();
                    return h;
                }
                else
                {
                    var resultat = res.FirstOrDefault();
                    resultat.DateConsultation = DateTime.Today;
                    db.SaveChanges();
                    return h;
                }
            }
        }

        public ICollection<Historique_UtilisateurProduitModel> afficherHistorique_UtilisateurProduit(int UtilisateurId)
        {
            using (var db = new ProjetContext())
            {
                var res = from h in db.historique_utilisateurProduits
                          join u in db.utilisateurs on h.UtilisateurId equals u.UtilisateurId
                          join p in db.produits on h.ProduitId equals p.ProduitId
                          where u.UtilisateurId == UtilisateurId
                          orderby h.DateConsultation descending
                          select new Historique_UtilisateurProduitModel
                          {
                              Nom = p.Nom,
                              Prix = p.Prix,
                              Categorie = p.Categorie,
                              DateConsultation = h.DateConsultation
                          }
                          ;

                return res.Take(5).ToList();
            }
        }

        public ICollection<ProduitClientAvisModel> listerAvisProduit(int ProduitId)
        {
            using (var db = new ProjetContext())
            {
                var res = from a in db.avis_clientProduits
                          join c in db.clients on a.UtilisateurId equals c.UtilisateurId
                          where a.ProduitId == ProduitId
                          select new ProduitClientAvisModel
                          {
                              Prenom = c.Prenom,
                              Nom = c.Nom,
                              Commentaire = a.Commentaire,
                              Note = a.Note,
                              ProduitId = a.ProduitId
                          };

                return res.ToList();
            }
        }

        public Promotion ajouterPromotion(Promotion p)
        {
            using (var db = new Dao.ProjetContext())
            {
                db.promotions.Add(p);
                db.SaveChanges();
                return p;
            }
        }

        public Promotion findPromotionbyId(int id)
        {
            using (var db = new Dao.ProjetContext())
            {
               
                return db.promotions.Find(id);

            }
        }

        public ICollection<Promotion> findAllPromotion()
        {
            using (var db = new Dao.ProjetContext())
            {

                return db.promotions.ToList();

            }
        }

        public ICollection<Promotion> getProduitIdPromo(string nameProduit)
        {
            using (var db = new Dao.ProjetContext())
            {
                var res = from p in db.promotions
                          join np in db.produits on p.ProduitId equals np.ProduitId
                          where p.NomPromotion==nameProduit
                          
                          select p;

                return res.ToList();
            }
        }

        public ICollection<ProduitCommande> afficheLigneDeCommande()
        {
            using (var db = new ProjetContext())
            {
                return db.produitCommandes.ToList();
            }
        }

        public ICollection<Panier> findAllPanier()
        {
            using (var db = new ProjetContext())
            {
                return db.paniers.ToList();
            }
        }

        public Catalogue findCatalogue(int id)
        {
            using (var db = new ProjetContext())
            {
                return db.catalogues.Find(id);
            }
        }

        public ICollection<Catalogue> findAllCatalogue()
        {
            using (var db = new ProjetContext())
            {
                return db.catalogues.ToList();
            }
        }
		
		 public Avis_ClientProduit trouverAvis(int UtilisateurId, int ProduitId)
        {
            using (var db = new ProjetContext())
            {
                var res = from a in db.avis_clientProduits
                          where a.UtilisateurId == UtilisateurId && a.ProduitId == ProduitId
                          select a;

                return res.ToList().FirstOrDefault();
            }
        }
    }
}