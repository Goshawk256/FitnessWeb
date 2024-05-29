using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using FitnessWeb.Models.Siniflar;
using Context = FitnessWeb.Models.Siniflar.Context;

namespace FitnessWeb.Controllers
{
    public class DanisanController : Controller
    {
        Context c = new Models.Siniflar.Context();
        public ActionResult Index()
        {
            var danisanlar = c.Danisanlars.Where(x => x.Durum == true).ToList();

            return View(danisanlar);
        }
        public ActionResult Guncelle(int Id)
        {
            
           
           
            var antrenör = c.Danisanlars.Find(Id);
            return View("Guncelle", antrenör);
        }
        [HttpPost]
        public ActionResult Update(Danisanlar a)
        {




            var antrenör = c.Danisanlars.Find(a.DanisanId);
            antrenör.DabisanMailAdresi = a.DabisanMailAdresi;
            antrenör.DanisanIsım = a.DanisanIsım;
            antrenör.DanisanSifre = a.DanisanSifre;
            antrenör.TelefonNo = a.TelefonNo;
            antrenör.Cinsiyet = a.Cinsiyet;
            antrenör.TelefonNo = a.TelefonNo;
            antrenör.DogumTarih = a.DogumTarih;
            antrenör.istenen = a.istenen;
            
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public ActionResult Ekle()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Danisanlar a)
        {
           
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                a.GörselUrl = "/Image/" + dosyaadi + uzanti;
            
            a.Durum = true;
            c.Danisanlars.Add(a);
            c.SaveChanges();
            Thread.Sleep(2000);

            return RedirectToAction("Index", "Danisan");


        }
        public ActionResult Sil(int Id)
        {
            var antrenör = c.Danisanlars.Find(Id);
            antrenör.Durum = false;
            c.SaveChanges();
            Thread.Sleep(2000);

            return RedirectToAction("Index", "Danisan");
        }
    }
}