using Fil_rouge_evente.Dao;
using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Fil_rouge_evente.Controllers
{
    public class MoyenPaiementController : Controller
    {
        // GET: MoyenPaiement
        IClient iclient = new ClientImpl();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjouterMoyenPaiement()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Connexion", "Client");
            }
        }

        [HttpPost]
        public ActionResult AjouterMoyenPaiement(int typePaiement)
        {
            if (ModelState.IsValid)
            {
                switch (typePaiement)
                {
                    case 0:
                        return RedirectToAction("AjouterCarteBancaire");
                    case 1:
                        return RedirectToAction("AjouterCheque");
                    case 2:
                        return RedirectToAction("AjouterFacture");
                    case 3:
                        return RedirectToAction("AjouterVirement");
                    default:
                        return View();

                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult AjouterCarteBancaire()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Connexion", "Client");
            }
        }

        [HttpPost]
        public ActionResult AjouterCarteBancaire(CarteBancaire cb)
        {
            if (ModelState.IsValid)
            {

                cb.Actif = true;
                cb.UtilisateurId = Convert.ToInt32(Session["ClientId"]);
                iclient.ajouterCarteBancaire(cb);
                return RedirectToAction("LoggedIn", "Client");
            }
            else
            {
                ModelState.AddModelError("", "Le mois et l'année d'expiration de la carte sont obligatoires");
                return View(cb);
            }

        }

        public ActionResult AjouterCheque()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Connexion", "Client");
            }
        }

        [HttpPost]
        public ActionResult AjouterCheque(Cheque c)
        {
            if (ModelState.IsValid)
            {
                c.Actif = true;
                c.UtilisateurId = Convert.ToInt32(Session["ClientId"]);
                iclient.ajouterCheque(c);
                return RedirectToAction("LoggedIn", "Client");
            }
            else
            {
                return View(c);
            }

        }

        public ActionResult AjouterFacture()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Connexion", "Client");
            }
        }

        [HttpPost]
        public ActionResult AjouterFacture(Facture f)
        {
            if (ModelState.IsValid)
            {
                f.Actif = true;
                f.UtilisateurId = Convert.ToInt32(Session["ClientId"]);
                iclient.ajouterFacture(f);
                return RedirectToAction("LoggedIn", "Client");
            }
            else
            {
                return View(f);
            }

        }

        public ActionResult AjouterVirement()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Connexion", "Client");
            }
        }

        [HttpPost]
        public ActionResult AjouterVirement(Virement v)
        {
            if (ModelState.IsValid)
            {
                v.Actif = true;
                v.UtilisateurId = Convert.ToInt32(Session["ClientId"]);
                iclient.ajouterVirement(v);
                return RedirectToAction("LoggedIn", "Client");
            }
            else
            {
                return View(v);
            }

        }
        public ActionResult ListerCartesBancaires()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {

                var res = iclient.listerCarteBancaire(Convert.ToInt32(Session["ClientId"]));
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Client");
            }
        }

        public ActionResult SupprimerPaiement(int id)
        {
            if (Convert.ToInt32(Session["RoleId"]) == 1)
            {
                iclient.supprimerMoyenPaiement(id);
                return RedirectToAction("ListerCartesBancaires");
            }
            else
            {
                return RedirectToAction("Connexion", "Client");
            }
        }

        public ActionResult AfficherFacture(int id)
        {
            //if(Convert.ToInt32(Session["RoleId"]) == 1)
            //{

            //    var res = iclient.afficherModelCreationPdfFacture(id);
            //    var resultat = res.FirstOrDefault();
            //    return View(resultat);
            //}
            //else
            //{
            //    return RedirectToAction("Connexion", "Client");
            //}
            return View();
        }

        //[HttpPost]
        //public ActionResult AfficherFacture()
        //{

        //}
    }
}