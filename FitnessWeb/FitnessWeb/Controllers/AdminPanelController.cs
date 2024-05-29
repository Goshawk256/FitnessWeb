using FitnessWeb.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FitnessWeb.Controllers
{
    [AllowAnonymous]
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Adminlogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Adminlogin(Admin d)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.AdminMailAdresi == d.AdminMailAdresi && x.AdminSifre == d.AdminSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AdminMailAdresi, false);
                Session["AdminMailAdresi"] = bilgiler.AdminMailAdresi.ToString();
                return RedirectToAction("Index", "AdminPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }


        }


    }
}