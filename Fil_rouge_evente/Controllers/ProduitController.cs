using Fil_rouge_evente.Metier;
using Fil_rouge_evente.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fil_rouge_evente.Controllers
{
    public class ProduitController : Controller
    {
        IAdministrateur iadmin = new AdministrateurImpl();
        IUtilisateur iutilisateur = new UtilisateurImpl();
        IClient iclient = new ClientImpl();
        // GET: Produit
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult AjouterProduit()
        {
          
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                ViewBag.CatalogueId = new SelectList(iadmin.listerCatalogue(), "CatalogueId", "NomCatalogue");
                return View();
            }
            else
            {
                return RedirectToAction("loginAdmin","Administrateur");
            }
        }

        [HttpPost]
        public ActionResult AjouterProduit(Produit p)
        {            
            iadmin.ajouterProduit(p);
            ViewBag.CatalogueId = new SelectList(iadmin.listerCatalogue(), "CatalogueId", "NomCatalogue");
            return RedirectToAction("ListerProduitsAdmin");
            
        }
        public ActionResult AfficherPanier()
        {

            List<ProduitCommande> Panierclient = new List<ProduitCommande>();
            //  Panierclient.Add(prod);
            //  Session["panier"] = Panierclient;
            ICollection<ProduitCommande> res = Session["listerProduits"] as ICollection<ProduitCommande>;
            Panierclient.Add(res.FirstOrDefault());
            
           

            return View(Panierclient);
        }


        public ActionResult ListerProduitsAdmin()
        {

            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.listerProduitCatalogue();

            
                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        public ActionResult ListeProduitCommande()
        {

            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iclient.afficheLigneDeCommande();
                Session["listeProduit"] = res;

                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        public ActionResult ModifierProduit(int id)
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                Produit p = iadmin.afficherProduit(id);
                ViewBag.CatalogueId = new SelectList(iadmin.listerCatalogue(), "CatalogueId", "Nom", p.CatalogueId);
                ViewBag.Message = "Modifier un produit";
                return View(p);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        [HttpPost]
        public ActionResult ModifierProduit(Produit p)
        {
            var res = iadmin.modifierProduit(p);

            return RedirectToAction("ListerProduitsAdmin");
        }

        public ActionResult SupprimerProduit(int id)
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                iadmin.supprimerProduit(id);
                return RedirectToAction("ListerProduitsAdmin");
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        public ActionResult RechercherProduitParNom()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.listerProduits();
                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        [HttpPost]
        public ActionResult RechercherProduitParNom(string Nom)
        {
            var res = iadmin.rechercherProduitsByName(Nom);
            return View(res);
        }

        public ActionResult RechercherProduitParId()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.listerProduits();
                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        [HttpPost]
        public ActionResult RechercherProduitParId(int id)
        {
            var res = iadmin.rechercherProduitById(id);
            return View(res);
        }


        public ActionResult AfficherProduit(int? id)
        {
            if (id.HasValue)
            {

                var id2 = (int)id;
                TempData["ProduitId"] = id2;

                if (Convert.ToInt32(Session["RoleId"]) == 1)
                {
                    var historique = new Historique_UtilisateurProduit
                    {
                        UtilisateurId = Convert.ToInt32(Session["ClientId"]),
                        ProduitId = id2,
                        DateConsultation = DateTime.Now
                    };
                    iutilisateur.ajouterHistorique_UtilisateurProduit(historique);
                }
                var res = iutilisateur.afficherProduit(id2);
                return View(res);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
       

        public ActionResult afficherPromotionProduit()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.afficherPromotionProduit();
                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        public ActionResult afficherPromotion()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                return View(iadmin.findAllPromotion());
            }
            else return RedirectToAction("Login", "Administrateur");

        }


        public ActionResult ajouterPromotion()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        [HttpPost]
        public ActionResult ajouterPromotion(Promotion p)
        {
            p.ProduitId = 5;
            
            iadmin.creerPromotion(p);
            return RedirectToAction("afficherPromotionProduit");
        }

        public ActionResult modifierPromotion(int id)
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                Promotion p = iadmin.findPromotionbyId(id);
                return View(p);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        [HttpPost]
        public ActionResult modifierPromotion(Promotion p)
        {
            p.ProduitId = 4;
            iadmin.modifierPromotion(p);
            return RedirectToAction("afficherPromotion");
        }



        public ActionResult supprimerPromotion(int PromotionId)
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                iadmin.supprimerPromotion(PromotionId);
                return RedirectToAction("afficherPromotionProduit");
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        

        public ActionResult listerProduitUtilisateur()
        {
            ViewBag.Message = "Liste des produits";
            if (Convert.ToBoolean(TempData["ErreurAvis"]) == true)
            {
                ViewBag.ErreurAvis = "Vous avez déjà mis un avis pour ce produit";
            }
            else if (Convert.ToBoolean(TempData["ErreurRole"]) == true)
            {
                ViewBag.ErreurAvis = "Vous devez être connecté pour poster un avis";
            }

            var res = iutilisateur.listerProduits();
            return View(res);

        }

        public ActionResult RechercherProduit()
        {
            var res = iutilisateur.listerProduits();
            return View(res);
        }


        [HttpPost]
        public ActionResult RechercherProduit(string Nom, int prixMin, int prixMax, string Categorie)
        {
            if (Convert.ToString(prixMin) == "" || Convert.ToString(prixMax) == "")
            {
                prixMin = 0;
                prixMax = 0;
                var resu = iutilisateur.listerProduits();
                return View(resu);
            }

            else if (prixMin != 0 || prixMax != 0)
            {
                //rechercher par prix
                if (prixMin <= prixMax)
                {
                    var resu = iutilisateur.rechercherProduits(prixMin, prixMax);
                    return View(resu);

                }
                else
                {
                    var resu = iutilisateur.listerProduits();
                    ViewBag.MessageErreurPrix = " Le prix minimum est supérieur au prix maximum";
                    return View(resu);
                }
            }


            //rechercher par categorie
            else if (Categorie != "")
            {

                var resul = iutilisateur.rechercherProduitsByCategorie(Categorie);
                if (resul.Count() != 0)
                {
                    return View(resul);
                }
                else
                {
                    ViewBag.MessageErreurCat = "La categorie saisie n'existe pas";
                    var result = iutilisateur.listerProduits();
                    return View(result);

                }

            }
            //else
            //{
            //    ViewBag.MessageErreur = "Avez vous saisie une catégorie ?";
            //    var resulta = iutilisateur.listerProduits();
            //    return View(resulta);
            //}

            //rechercher par nom
            else if (Nom != "")
            {
                var res = iutilisateur.rechercherProduitsByName(Nom);
                if (res.Count() != 0)
                {
                    return View(res);
                }

                else
                {
                    ViewBag.MessageErreurNom = "  le produit saisi ne fait plus partie du catalogue";
                    var resu = iutilisateur.listerProduits();
                    return View(resu);
                }
            }
            else
            {
                

                ViewBag.MessageErreur = " Champs de saisi vide";
                var resu = iutilisateur.listerProduits();
                return View(resu);
            }




        }

        [HttpPost]
        public ActionResult listerProduitUtilisateur(string Nom)
        {
            var res = iadmin.rechercherProduitsByName(Nom);
            return View(res);
        }



        public ActionResult afficherHistoriqueProduits()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                var res = iutilisateur.afficherHistorique_UtilisateurProduit(Convert.ToInt32(Session["ClientId"]));
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Client");

            }
        }

        //public ActionResult afficherProduitModel()
        //{
        //    ICollection<ProduitModel> listesP = iadmin.findAllProduitandCat();
        //    return View(listesP);
        //}

        public ActionResult creationPdf()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {

                var res = iutilisateur.afficherHistorique_UtilisateurProduit(Convert.ToInt32(Session["ClientId"]));
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Client");

            }
        }

        public ActionResult creationPdfHistorique()
        {

            var res = iutilisateur.afficherHistorique_UtilisateurProduit(Convert.ToInt32(Session["ClientId"]));

            return new ViewAsPdf("creationPdf", res);
        }

        public ActionResult ajouterAvisProduit(string Commentaire, int Note)
        {
            var id = Convert.ToInt32(TempData["ProduitId"]);
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                
                var comm = new Avis_ClientProduit
                {
                    UtilisateurId = Convert.ToInt32(Session["ClientId"]),
                    Commentaire = Commentaire,
                    Note = Note,
                    ProduitId = id
                };

                var res = iclient.trouverAvis(Convert.ToInt32(Session["ClientId"]), id);
                if (res == null)
                {
                    iclient.ajouterAvis(comm);
                }
                else
                {
                    TempData["ErreurAvis"] = true;

                }
            }
            else
            {
                TempData["ErreurRole"] = true;
            }
            return RedirectToAction("listerProduitUtilisateur");
            
        }

        public ActionResult afficherAvisProduit(int? id)
        {
            if(id.HasValue)
            {
                var id2 = (int)id;
                var res = iutilisateur.listerAvisProduit(id2);
                return View(res);
            }
            else
            {
                return RedirectToAction("listerProduitUtilisateur");
            }
        }

    }
}