using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var cariler = c.Carilers.Count().ToString();
            ViewBag.cari = cariler;
            var urunler = c.Uruns.Count().ToString();
            ViewBag.urun = urunler;
            var kategoriler = c.Kategoris.Count().ToString();
            ViewBag.kategori = kategoriler;
            var cariSehirler = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.cariSehir = cariSehirler;

            var yapilacaklar = c.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
    }
}