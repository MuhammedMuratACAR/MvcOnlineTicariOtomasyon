using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler cari)
        {
            c.Carilers.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari=c.Carilers.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir",cari);
        }

        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");

            }
            var caris = c.Carilers.Find(p.CariID);
            caris.CariAd = p.CariAd;
            caris.CariSoyad = p.CariSoyad;
            caris.CariSehir = p.CariSehir;
            caris.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        
        }

        public ActionResult CariSatisDetay(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            var carisAd = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + "  " + y.CariSoyad).FirstOrDefault();
            ViewBag.cariAd = carisAd;
            return View(deger);
        }
    }
}
