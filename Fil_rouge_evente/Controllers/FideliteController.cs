using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fil_rouge_evente.Controllers
{
    public class FideliteController : Controller
    {
        IAdministrateur iadmin = new AdministrateurImpl();
        // GET: Fidelite
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ajouterFidelite()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("loginAdmin");
            }
        }

        [HttpPost]
        public ActionResult ajouterFidelite(Fidelite f)
        {
            return RedirectToAction("listerFidelite");
        }

        public ActionResult listerFidelite()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.listerFidelite();
                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin");
            }
        }

        public ActionResult supprimerFidelite(int FideliteId)
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                iadmin.supprimerFidelite(FideliteId);
                return RedirectToAction("listerFidelite");
            }
            else
            {
                return RedirectToAction("loginAdmin");
            }
        }

        public ActionResult afficherFidelite(int FideliteId)
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.afficherFidelite(FideliteId);
                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin");
            }
        }

        public ActionResult modifierFidelite(int FideliteId)
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.afficherFidelite(FideliteId);
                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin");
            }
        }

        [HttpPost]
        public ActionResult modifierFidelite(Fidelite f)
        {
            iadmin.modifierFidelite(f);
            return RedirectToAction("listerFidelite");
        }
    }
}