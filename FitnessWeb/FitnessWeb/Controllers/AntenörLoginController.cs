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
    public class AntenörLoginController : Controller
    {
        // GET: AntenörLogin
        Context c = new Context();
        public ActionResult Index()
        {
            var mail = (string)Session["AntMailAdresi"];
            var degerler = c.Antrenörs.FirstOrDefault(x => x.AntMailAdresi == mail);
            ViewBag.m = mail;
            List<SelectListItem> deger1 = (from x in c.Kategoris.Where(x=> x.durum ==  true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.kategori = deger1;
            List<SelectListItem> deger3 = (from x in c.Danisanlars.Where(x => x.Durum == true).ToList()
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
            return View(degerler);
            
        }

        [HttpGet]
        public ActionResult AntLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AntLogin(Antrenör d)
        {
            var bilgiler = c.Antrenörs.FirstOrDefault(x => x.AntMailAdresi == d.AntMailAdresi && x.AntSifre == d.AntSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AntMailAdresi, false);
                Session["AntMailAdresi"] = bilgiler.AntMailAdresi.ToString();
                return RedirectToAction("Index", "AntenörLogin");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }


        }
        public ActionResult AntBilgiGüncelle(Antrenör d)
        {


            var antrenör = c.Antrenörs.Find(d.AntrenörId);
            antrenör.tercihId = d.tercihId;
            antrenör.DnId = d.DnId;
            antrenör.Antrenörİsim = d.Antrenörİsim;
            antrenör.AntSifre = d.AntSifre;
            antrenör.AntMailAdresi = d.AntMailAdresi;
            antrenör.DogumTarih = d.DogumTarih;
            antrenör.Deneyim = d.Deneyim;
            antrenör.kategoriId = d.kategoriId;
            
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult GelenMesaj()
        {
            var mail = (string)Session["AntMailAdresi"];
            var mesajlar = c.Mesajlars.Where(x => x.kime == mail).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.kime == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gönderilen = c.Mesajlars.Count(x => x.kimden == mail).ToString();
            ViewBag.d2 = gönderilen;
            return View(mesajlar);
        }

        public ActionResult Gidenmesajlar()
        {
            var mail = (string)Session["AntMailAdresi"];
            var mesajlar = c.Mesajlars.Where(x => x.kimden == mail).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.kime == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gönderilen = c.Mesajlars.Count(x => x.kimden == mail).ToString();
            ViewBag.d2 = gönderilen;
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.mesajid == id).ToList();
            var mail = (string)Session["AntMailAdresi"];
            var gelensayisi = c.Mesajlars.Count(x => x.kime == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gönderilen = c.Mesajlars.Count(x => x.kimden == mail).ToString();
            ViewBag.d2 = gönderilen;
            return View(degerler);
        }
        public ActionResult GidenMesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.mesajid == id).ToList();
            var mail = (string)Session["AntMailAdresi"];
            var gelensayisi = c.Mesajlars.Count(x => x.kime == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gönderilen = c.Mesajlars.Count(x => x.kimden == mail).ToString();
            ViewBag.d2 = gönderilen;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["AntMailAdresi"];
            var gelensayisi = c.Mesajlars.Count(x => x.kime == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gönderilen = c.Mesajlars.Count(x => x.kimden == mail).ToString();
            ViewBag.d2 = gönderilen;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["AntMailAdresi"];
            m.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.kimden = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();

            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Danisanlar()
        {
            
            var danisanlar = c.Danisanlars.Where(x=> x.Durum==true).ToList();

            return View(danisanlar);
        }
       
        [HttpGet]
        public ActionResult DanisaGuncelle(int Id)
        {
            
          
            var danisan = c.Danisanlars.Find(Id);
            return View("DanisaGuncelle", danisan);
        }
        [HttpGet]
        public ActionResult DanisanEgzersizGuncelle(int Id)
        {


            var danisan = c.Danisanlars.Find(Id);
            return View("DanisanEgzersizGuncelle", danisan);
        }

        [HttpGet]
        public ActionResult DanisanDegerler(int Id)
        {


            var danisan = c.Danisanlars.Find(Id);
            return View("DanisanDegerler", danisan);
        }
        [HttpPost]
        public ActionResult Update(Danisanlar a)
        {




            var antrenör = c.Danisanlars.Find(a.DanisanId);
            antrenör.ogun1 = a.ogun1;
            antrenör.ogun2 = a.ogun2;
            antrenör.ogun3 = a.ogun3;
            antrenör.ogun4 = a.ogun4;
            antrenör.ogun5 = a.ogun5;
            antrenör.ogun6 = a.ogun6;
            antrenör.eg1 = a.eg1;
            antrenör.eg2 = a.eg2;
            antrenör.eg3 = a.eg3;
            antrenör.eg4 = a.eg4;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpPost]
        public ActionResult Updateegzersiz(Danisanlar a)
        {




            var antrenör = c.Danisanlars.Find(a.DanisanId);
            antrenör.eg1 = a.eg1;
            antrenör.eg2 = a.eg2;
            antrenör.eg3 = a.eg3;
            antrenör.eg4 = a.eg4;
            
            c.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}