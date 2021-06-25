using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()

        {
            List<SelectListItem> degerler = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.depart = degerler;
         
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count>0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                //string yol = "~/Views/Personel/Images/" + dosyaAdi+uzanti;
                string yol = "~/Images/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                //p.PersonelGorsel = "~/Views/Personel/Images/" + dosyaAdi+uzanti;
                p.PersonelGorsel = "/Images/" + dosyaAdi;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = c.Personels.Find(id);
            personel.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> degerler = (from x in c.Departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanID.ToString()
                                             }).ToList();
            ViewBag.depart = degerler;
            var per = c.Personels.Find(id);
            return View("PersonelGetir",per);

        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                //string yol = "~/Views/Personel/Images/" + dosyaAdi+uzanti;
                string yol = "~/Images/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                //p.PersonelGorsel = "~/Views/Personel/Images/" + dosyaAdi+uzanti;
                p.PersonelGorsel = "/Images/" + dosyaAdi;
            }
            var per = c.Personels.Find(p.PersonelID);
            per.PersonelAd = p.PersonelAd;
            per.PersonelSoyad = p.PersonelSoyad;
            per.PersonelGorsel = p.PersonelGorsel;
            per.DepartmanID = p.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult PersonelSatisDetay(int id)
        //{
        //    var deger = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
        //    var perad = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
        //    ViewBag.per = perad;
        //        return View(deger);
        //}

        public ActionResult PersonelListe()
        {
            var sorguPersonel = c.Personels.ToList();
            return View(sorguPersonel);
        }
    }
}