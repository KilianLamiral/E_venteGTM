using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fil_rouge_evente.Controllers
{
    public class RoleController : Controller
    {
        IAdministrateur iadmin = new AdministrateurImpl();
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjouterRole()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)

                return View();
            else return RedirectToAction("LoginAdmin", "Administrateur");
        }

        [HttpPost]
        public ActionResult AjouterRole(Role r)
        {
            var res = iadmin.ajouterRole(r);
            return RedirectToAction("ListerRoles");
        }

        public ActionResult ListerRoles()
        {
            if (Convert.ToInt32(Session["RoleId"]) == 2)
            {
                var res = iadmin.listerRoles();
                return View(res);
            }
            else return RedirectToAction("LoginAdmin", "Administrateur");
        }
    }
}