using FitnessWeb.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace FitnessWeb.Controllers
{
    public class DanisanPanelController : Controller
    {
        // GET: DanisanPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["DabisanMailAdresi"];
            var degerler = c.Danisanlars.FirstOrDefault(x => x.DabisanMailAdresi == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult DanisanBilgiGüncelle(Danisanlar d)
        {

           
            var danisan = c.Danisanlars.Find(d.DanisanId);
            danisan.Cinsiyet = d.Cinsiyet;
            danisan.DanisanIsım = d.DanisanIsım;
            danisan.DanisanSifre = d.DanisanSifre;
            danisan.DabisanMailAdresi = d.DabisanMailAdresi;
            danisan.TelefonNo = d.TelefonNo;
            danisan.DogumTarih = d.DogumTarih;
          
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult SifreReset()
        {
            return View();
                 
        }
            [HttpPost]
        public ActionResult SifreReset(Danisanlar d)
        {
            var model = c.Danisanlars.Where(x => x.DabisanMailAdresi == d.DabisanMailAdresi).FirstOrDefault();
            if(model!=null)
            {
                SmtpClient smtpClient = new SmtpClient("smtp.outlook.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("muratakay123456@outlook.com", "Akay123456");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("muratakay123456@outlook.com", "User");
                mail.To.Add(new MailAddress(model.DabisanMailAdresi));
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpClient.Send(mail);

            }

          
            else
            {
                ViewBag.uyari = "hata oluştu tekrar deneyiniz";

               
            }
            return View();
        }

        public ActionResult Kategoriler()
        {
            var deger = c.Kategoris.Where(x=> x.durum == true).ToList();
            return View(deger);
        }

        public ActionResult kategori1(int id)
        {
            var deger = c.Antrenörs.Where(x => x.kategoriId == id).ToList();
            var deger2 = c.Antrenörs.Select(x => x.AntMailAdresi).FirstOrDefault();
            ViewBag.ma = deger2;
            return View(deger);

        }
        public ActionResult degerler()
        {
            var mail = (string)Session["DabisanMailAdresi"];
            var degerler = c.Danisanlars.FirstOrDefault(x => x.DabisanMailAdresi == mail);
            ViewBag.m = mail;
            return View(degerler);

        }

        public ActionResult degergüncelle(Danisanlar d)
        {


            var danisan = c.Danisanlars.Find(d.DanisanId);
            danisan.boy = d.boy;
            danisan.Kilo = d.Kilo;
            danisan.kitleindex = d.kitleindex;
            danisan.vctyag = d.vctyag;
            danisan.kaskütlesi = d.kaskütlesi;
            danisan.DogumTarih = d.DogumTarih;

            c.SaveChanges();
            return RedirectToAction("degerler");

        }

        public ActionResult GelenMesaj()
        {
            var mail = (string)Session["DabisanMailAdresi"];
            var mesajlar = c.Mesajlars.Where(x=> x.kime == mail).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.kime == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gönderilen = c.Mesajlars.Count(x => x.kimden == mail).ToString();
            ViewBag.d2 = gönderilen;
            return View(mesajlar);
        }


        public ActionResult Gidenmesajlar()
        {
            var mail = (string)Session["DabisanMailAdresi"];
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
            var mail = (string)Session["DabisanMailAdresi"];
            var gelensayisi = c.Mesajlars.Count(x => x.kime == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gönderilen = c.Mesajlars.Count(x => x.kimden == mail).ToString();
            ViewBag.d2 = gönderilen;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["DabisanMailAdresi"];
            var gelensayisi = c.Mesajlars.Count(x => x.kime == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gönderilen = c.Mesajlars.Count(x => x.kimden == mail).ToString();
            ViewBag.d2 = gönderilen;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["DabisanMailAdresi"];
            m.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.kimden = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();

            return View();
        }

        public ActionResult EgzersizBeslenme()
        {
            var mail = (string)Session["DabisanMailAdresi"];
            var danisan = c.Danisanlars.Where(x => x.DabisanMailAdresi == mail).ToList();
            return View(danisan);

        }

    }
}