using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = context.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult BlogEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogEkle(Blog eklencek)
        {
            context.Blogs.Add(eklencek);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult BlogSil(int id)
        {
            var varolan = context.Blogs.Find(id);
            context.Blogs.Remove(varolan);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult BlogGetir(int id)
        {
            var varolan = context.Blogs.Find(id);
            return View("BlogGetir", varolan);
        }
        public ActionResult BlogGuncelle(Blog yeni)
        {
            var eski = context.Blogs.Find(yeni.ID);
            eski.Aciklama = yeni.Aciklama;
            eski.Tarih = yeni.Tarih;
            eski.Baslik = yeni.Baslik;
            eski.BlogImage = yeni.BlogImage;

            context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = context.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var varolan = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(varolan);
            context.SaveChanges();
            return RedirectToAction("YorumListesi", "Admin");
        }
        public ActionResult YorumGetir(int id)
        {
            var varolan = context.Yorumlars.Find(id);
            return View("YorumGetir", varolan);
        }
        public ActionResult YorumGuncelle(Yorumlar yeni)
        {
            var eski = context.Yorumlars.Find(yeni.ID);
            eski.KullaniciAdi = yeni.KullaniciAdi;
            eski.Mail = yeni.Mail;
            eski.Yorum = yeni.Yorum;


            context.SaveChanges();
            return RedirectToAction("YorumListesi", "Admin");
        }
    }
}