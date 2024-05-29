using FitnessWeb.Models.Siniflar;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FitnessWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Models.Siniflar.Context x = new Models.Siniflar.Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult ParitalKayit()
        {
            List<SelectListItem> deger1 = (from x in x.Kategoris.Where(x => x.durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.kategori = deger1;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ParitalKayit(Danisanlar d)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                d.GörselUrl = "/Image/" + dosyaadi + uzanti;
            }
            d.Durum = true;
            x.Danisanlars.Add(d);
            Thread.Sleep(2000);
            x.SaveChanges();
            return PartialView();
           
           
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Danisanlar d)
        {
            var bilgiler = x.Danisanlars.FirstOrDefault(x => x.DabisanMailAdresi == d.DabisanMailAdresi && x.DanisanSifre == d.DanisanSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.DabisanMailAdresi, false);
                Session["DabisanMailAdresi"] = bilgiler.DabisanMailAdresi.ToString();
                return RedirectToAction("Index", "DanisanPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }


        }

       

    }
}