using FitnessWeb.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FitnessWeb.Controllers
{
    public class AntrenörController : Controller
    {
        // GET: Antrenör
        Context c = new Context();
        public ActionResult Index()
        {
            var antrenörler = c.Antrenörs.Where(x => x.Durum == true).ToList();

            return View(antrenörler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> deger3 = (from x in c.Danisanlars.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DanisanIsım,
                                               Value = x.DanisanId.ToString()
                                           }).ToList();
            ViewBag.danisan = deger3;
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.kategori = deger1;
            List<SelectListItem> deger2 = (from x in c.Cinsiyet.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Tercih,
                                               Value = x.CinsiyetId.ToString()
                                           }).ToList();
            ViewBag.cinsiyet = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Antrenör a)
        {
            if (a.Antgörsel!=null)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                a.Antgörsel = "/Image/" + dosyaadi + uzanti;
            }
            a.Durum = true;
            c.Antrenörs.Add(a);
            c.SaveChanges();
            Thread.Sleep(2000);
           
            return RedirectToAction("Index", "Antrenör");


        }
        public ActionResult Sil(int Id)
        {
            var antrenör = c.Antrenörs.Find(Id);
            antrenör.Durum = false;
            c.SaveChanges();
            Thread.Sleep(2000);

            return RedirectToAction("Index", "Antrenör");
        }
        [HttpGet]
        public ActionResult Guncelle(int Id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.kategori = deger1;
         
            List<SelectListItem> deger3 = (from x in c.Danisanlars.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DanisanIsım,
                                               Value = x.DanisanId.ToString()
                                           }).ToList();
            ViewBag.danisan = deger3;
            List<SelectListItem> deger2 = (from x in c.Cinsiyet.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Tercih,
                                               Value = x.CinsiyetId.ToString()
                                           }).ToList();
            ViewBag.cinsiyet = deger2;
            var antrenör = c.Antrenörs.Find(Id);
            return View("Guncelle",antrenör);
        }
        [HttpPost]
        public ActionResult Update(Antrenör a)
        {

         
              
           
            var antrenör = c.Antrenörs.Find(a.AntrenörId);
            antrenör.Antrenörİsim = a.Antrenörİsim;
            antrenör.AntMailAdresi = a.AntMailAdresi;
            antrenör.Antgörsel = a.Antgörsel;
            antrenör.AntSifre = a.AntSifre;
            antrenör.AntSifre = a.AntSifre;
            antrenör.TelefonNo = a.TelefonNo;
            antrenör.kategoriId = a.kategoriId;
            antrenör.tercihId = a.tercihId;
            antrenör.DogumTarih = a.DogumTarih;
            antrenör.DnId = a.DnId;
            c.SaveChanges();
            return RedirectToAction("Index");
          

        }

        


    }
}