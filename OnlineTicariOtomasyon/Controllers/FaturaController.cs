using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Faturalars.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var degerler = c.Faturalars.Find(id);
            return View("FaturaGetir",degerler);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var ftr=c.Faturalars.Find(f.FaturaID);
            ftr.FaturaSeriNo = f.FaturaSeriNo;
            ftr.FaturaSiraNo = f.FaturaSiraNo;
            ftr.VergiDairesi = f.VergiDairesi;            
            ftr.Saat = f.Saat;
            ftr.Tarih = f.Tarih;
            ftr.Toplam = f.Toplam;
            ftr.TeslimAlan = f.TeslimAlan;
            ftr.TeslimEden = f.TeslimEden;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var deger = c.FaturaKalems.Where(x => x.FaturaID == id).ToList();
            var ftrId = c.FaturaKalems.Where(x => x.FaturaID == id).Select(y=>y.FaturaID).FirstOrDefault();
            ViewBag.ftrID = ftrId;
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniKalem(int id)
        {

            var ftrId = c.FaturaKalems.Where(x => x.FaturaID == id).Select(y => y.FaturaID).FirstOrDefault();
            ViewBag.faturaID = ftrId;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
            c.FaturaKalems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DinamikFatura()
        {
            DinamikFatura df = new DinamikFatura();
            df.Fatura = c.Faturalars.ToList();
            df.FaturaKalem = c.FaturaKalems.ToList();
            return View(df);
        }

        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSiraNo, string Tarih, string Saat, string VergiDairesi, string TeslimEden, string TeslimAlan, decimal Toplam, FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSiraNo;
            f.VergiDairesi = VergiDairesi;
            f.Tarih = DateTime.Parse(Tarih).Date;
            f.Saat = Saat;
            f.TeslimAlan = TeslimAlan;
            f.TeslimEden = TeslimEden;
            f.Toplam = Toplam;
            c.Faturalars.Add(f);
            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama = x.Aciklama;
                fk.BirimFiyat = x.BirimFiyat;
                fk.FaturaID = x.FaturaKalemID;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}

