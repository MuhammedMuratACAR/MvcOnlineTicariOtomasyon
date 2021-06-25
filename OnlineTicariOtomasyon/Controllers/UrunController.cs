using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urun = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urun = urun.Where(y => y.UrunAd.Contains(p));
            }
            //var urun = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urun.ToList());
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id);
            urun.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urun = c.Uruns.Find(id);

            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(Urun u)
        {
            var urun = c.Uruns.Find(u.UrunID);
            urun.UrunAd = u.UrunAd;
            urun.Marka = u.Marka;
            urun.Stok = u.Stok;
            urun.AlisFiyati = u.AlisFiyati;
            urun.SatisFiyati = u.SatisFiyati;
            urun.KategoriID = u.KategoriID;
            urun.UrunGorsel = u.UrunGorsel;
            urun.Durum = u.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunListelemesi()
        {
            var deger = c.Uruns.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> personeller = (from x in c.Personels.Where(x => x.Durum == true).ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelID.ToString()
                                                }).ToList();

            List<SelectListItem> cariler = (from x in c.Carilers.Where(x => x.Durum == true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();

            var urunDeger = c.Uruns.Find(id);
            ViewBag.urunId = urunDeger.UrunID;
            ViewBag.fiyat = urunDeger.SatisFiyati;
            ViewBag.personel = personeller;
            ViewBag.cari = cariler;

            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket satis)
        {
            satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(satis);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}