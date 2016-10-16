using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fil_rouge_evente.Controllers
{
    public class CatalogueController : Controller
    {
        IAdministrateur iadmin = new AdministrateurImpl();
        // GET: Catalogue
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ajouterCatalogue()
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
        public ActionResult ajouterCatalogue(Catalogue c)
        {
            iadmin.ajouterCatalogue(c);
            return RedirectToAction("loggedInAdmin","Administrateur");
        }

        public ActionResult listerCatalogue()
        {
            var roleid = (int)(Session["RoleId"]);
            if ((Session["UtilisateurId"] != null) && (roleid == 2))
            {
                var res = iadmin.listerCatalogue();
                return View(res);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        public ActionResult modifierCatalogue(int id)
        {
            var roleid = (int)(Session["RoleId"]);
            if ((Session["UtilisateurId"] != null) && (roleid == 2))
            {
                Catalogue c = iadmin.afficherCatalogue(id);
                ViewBag.CatalogueId = new SelectList(iadmin.listerCatalogue(), "CatalogueId", "Nom", c.CatalogueId);
                return View(c);
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }

        [HttpPost]
        public ActionResult ModifierCatalogue(Catalogue c)
        {
            iadmin.modifierCatalogue(c);

            return RedirectToAction("listerCatalogue");
        }
        public ActionResult SupprimerCatalogue(int id)
        {
            var roleid = (int)(Session["RoleId"]);
            if ((Session["UtilisateurId"] != null) && (roleid == 2))
            {
                iadmin.supprimerCatalogue(id);
                return RedirectToAction("listerCatalogue");
            }
            else
            {
                return RedirectToAction("loginAdmin", "Administrateur");
            }
        }
    }
}