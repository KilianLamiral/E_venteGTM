using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fil_rouge_evente.Controllers
{
    public class AdministrateurController : Controller
    {
        IAdministrateur iadmin = new AdministrateurImpl();
        // GET: Administrateur
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ajouterAdministrateur()
        {
            ViewBag.Message = "Ajouter admin";
            if (Convert.ToInt32(Session["RoleId"]) == 2)
                return View();
            else return RedirectToAction("loginAdmin");
        }

        [HttpPost]
        public ActionResult ajouterAdministrateur(Administrateur a)
        {
            iadmin.creationCompteAdmin(a);
            return RedirectToAction("listerAdministrateur");
        }

        public ActionResult listerAdministrateur()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                ViewBag.Message = "Lister admin";
                var res = iadmin.listerComptes();
                return View(res);
            }
            else return RedirectToAction("loginAdmin");
        }

        public ActionResult loginAdmin()
        {
            ViewBag.Message = "Connexion";
            return View();
        }

        [HttpPost]
        public ActionResult loginAdmin(Utilisateur u)
        {



            var user = iadmin.connexionCompte(u);
            if (user != null)
            {
              
                Session["UtilisateurId"] = user.UtilisateurId;
                Session["RoleId"] = user.RoleId;
                return RedirectToAction("LoggedInAdmin");
            }
            else
            {
                ModelState.AddModelError("", "Utilisateur ou mot de passe incorrect");
                return View(u);
            }
        }

        public ActionResult loggedInAdmin()
        {
            ViewBag.Message = "Admin";
            if ((Convert.ToInt32(Session["RoleId"]) == 2))
            {
                return View();
            }
            else
            {
                return RedirectToAction("loginAdmin");
            }
        }

        public ActionResult logout()
        {
            Session["UtilisateurId"] = null;
            Session["RoleId"] = null;

            return RedirectToAction("loginAdmin");
        }

        public ActionResult listerClient()
        {
            ICollection<Client> res = iadmin.listerClient();
            ViewBag.Message = "Liste des clients";
            return View(res);
        }

        [HttpPost]
        public ActionResult listerClient(string nom)
        {
            ICollection<Client> res = iadmin.rechercherClientByName(nom);
            return View(res);
        }

        public ActionResult changerEtatClient(int id)
        {
            iadmin.changerEtatClient(id);
            return RedirectToAction("listerClient");
        }
    }
}