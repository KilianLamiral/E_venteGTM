using Fil_rouge_evente.Metier;
using Fil_rouge_evente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fil_rouge_evente.Controllers
{
    public class PromotionController : Controller
    {
        IAdministrateur iadmin = new AdministrateurImpl();
        // GET: Promotion
        public ActionResult Index()
        {
            return View();
        }

       


        public ActionResult afficherPromotionProduit()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.afficherPromotionProduit();
                return View(res);
            }
            else return RedirectToAction("loginAdmin", "Administrateur");

        }
    }
}