
using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik

        Context C = new Context();
        public ActionResult Index()
        {
            var cari = C.Carilers.Count().ToString();
            ViewBag.cariler = cari;
            var urun = C.Uruns.Count().ToString();
            ViewBag.urunler = urun;
            var personel = C.Personels.Count().ToString();
            ViewBag.personeller = personel;
            var kategori = C.Kategoris.Count().ToString();
            ViewBag.kategoriler = kategori;
            var stok = C.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.stoks = stok;
            var marka = (from x in C.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.markas = marka;
            var kritik = C.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.kritikSeviye = kritik;
            var maxFiyat = (from x in C.Uruns orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault();
            ViewBag.maxFiyats = maxFiyat;
            var minFiyat = (from x in C.Uruns orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault();
            ViewBag.minFiyats = minFiyat;
            var maxMarka = C.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.maxMarkas = maxMarka;
            var buzdolabi = C.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.buzdolabis = buzdolabi;
            var mouse = C.Uruns.Count(x => x.UrunAd == "Mouse").ToString();
            ViewBag.mouses = mouse;
            var kasadakiTutar = C.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.kasadakiTutars = kasadakiTutar;
            var enCokSatan = C.Uruns.Where(u => u.UrunID == (C.SatisHarekets.GroupBy(x => x.UrunID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.enCokSatans = enCokSatan;

            DateTime bugun = DateTime.Today;
            var bugunSatis = C.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.bugunSatiss = bugunSatis;

            var bugunSatisKasa = C.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y =>(decimal?) y.ToplamTutar).ToString();
            ViewBag.bugunSatisKasas = bugunSatisKasa;
            return View();
        }

        public ActionResult SimpleTable()
        {
            var sorgu = from x in C.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };

            return View(sorgu.ToList());
        }
        public PartialViewResult PartialTable()
        {
            var sorgu = from x in C.Personels
                        group x by x.Departman.DepartmanAd into g
                        select new SinifGrup2
                        {
                            Departman = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }

        public PartialViewResult CariPartial()
        {
            var sorguCari = C.Carilers.Where(x=>x.Durum==true).ToList();
            return PartialView(sorguCari);
        }

        public PartialViewResult UrunPartial()
        {
            var sorguUrun = C.Uruns.Where(x => x.Durum == true).ToList();
            return PartialView(sorguUrun);
        }

        public PartialViewResult MarkaList()
        {
            var sorguMarka = from x in C.Uruns
                        group x by x.Marka into g
                        select new MarkaSinif
                        {
                            Marka = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorguMarka.ToList());
          
        }
    }
}