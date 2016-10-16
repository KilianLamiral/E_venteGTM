using Fil_rouge_evente.Metier;
using Fil_rouge_evente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fil_rouge_evente.Controllers
{
    public class ClientController : Controller
    {
        IClient iclient = new ClientImpl();
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
         

        public ActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(ClientModel c)
        {
            iclient.creationCompteClient(c);
            return RedirectToAction("Connexion");
        }

        public ActionResult Connexion()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Connexion(Utilisateur ut)
        {
            var monUser = iclient.connexionCompte(ut);

            if(monUser != null)
            {
                
                Session["RoleId"] = monUser.RoleId;
                Session["ClientId"] = monUser.UtilisateurId;
                Session["Nom"] = monUser.Nom;
                Session["Prenom"] = monUser.Prenom;
             
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Utilisateur ou mot de passe incorrect");
                return View();
            }
        }

        public ActionResult LoggedIn()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Connexion");             
            }
        }

        public ActionResult logout(Client c)
        {
            Session["ClientId"] = null;
            Session["RoleId"] = null;
            Session["Nom"] = null;
            Session["Prenom"] = null;
            return RedirectToAction("Connexion");
        }

        public ActionResult ModifierCompte()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                var res = iclient.afficherCompte(Convert.ToInt32(Session["ClientId"]));
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion");
            }
        }

        [HttpPost]
        public ActionResult ModifierCompte(Client c)
        {
            iclient.modifierCompte(c);
            return RedirectToAction("LoggedIn");
        }

        public ActionResult AjouterAdresse()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Connexion");
            }
        }

        [HttpPost]
        public ActionResult AjouterAdresse(Adresse a)
        {
            var clientid = (int)(Session["ClientId"]);
            var adresse = iclient.ajouterAdresse(a);
            iclient.ajouterAdresseClient(adresse.AdresseId,clientid);
            
            return RedirectToAction("LoggedIn");
        }

        public ActionResult SupprimerAdresse(int id)
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                iclient.supprimerAdresse(id);
                return RedirectToAction("AfficherAdresses");
            }
            else
            {
                return RedirectToAction("Connexion");
            }
        }

        public ActionResult AfficherAdresses()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                var clientid = (int)(Session["ClientId"]);
                var res = iclient.listerAdresse(clientid);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion");
            }
        }

        public ActionResult modifierAdresse(int id)
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                var res = iclient.afficherAdresse(id);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion");
            }
        }

        [HttpPost]
        public ActionResult modifierAdresse(Adresse a)
        {
            iclient.modifierAdresse(a);
            return RedirectToAction("AfficherAdresses");
        }
        public ActionResult desactiverMonCompte(int id)
        {
            iclient.desactiverMonCompte(id);
            ViewBag.Message = "Votre demande de suppression sera soumise à l'équipe.";
            return RedirectToAction("ModifierCompte");
        }

      

        //public ActionResult ajouterProduitPanier()
        //{
           
        //    iclient.ajouterProduitPanier();

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ajouterProduitPanier(ProduitCommande pc)
        //{

        //    iclient.ajouterProduitPanier(pc);

        //    return RedirectToAction("AfficherPanier");
        //}







    }
}