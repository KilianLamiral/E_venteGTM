using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fil_rouge_evente.Controllers
{
    public class AnniversaireController : Controller
    {
        IAdministrateur iadmin = new AdministrateurImpl();
        // GET: Anniversaire
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ajouterAnniversaire()
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
        public ActionResult ajouterAnniversaire(Anniversaire a)
        {
            iadmin.ajouterAnniversaire(a);
            return RedirectToAction("listerAnniversaires");
        }

        public ActionResult listerAnniversaires()
        {

            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.listerAnniversaires();
                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        public ActionResult supprimerAnniversaire(int AnniversaireId)
        {

            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                iadmin.supprimerAnniversaire(AnniversaireId);
                return RedirectToAction("listerAnniversaires");
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        public ActionResult modifierAnniversaire(int AnniversaireId)
        {

            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.afficherAnniversaire(AnniversaireId);
                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        [HttpPost]
        public ActionResult modifierAnniversaire(Anniversaire a)
        {
            var res = iadmin.modifierAnniversaire(a);
            return RedirectToAction("listerAnniversaires");
        }


    }
}