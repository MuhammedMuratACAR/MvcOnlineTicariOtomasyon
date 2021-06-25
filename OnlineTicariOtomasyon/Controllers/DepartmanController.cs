using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
       
        public ActionResult Index()
        {
            var departman = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(departman);
        }

        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var depart = c.Departmans.Find(id);
            depart.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = c.Departmans.Find(id);
            return View("DepartmanGetir",departman);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var departman = c.Departmans.Find(d.DepartmanID);
            departman.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var deger = c.Personels.Where(x => x.DepartmanID == id).ToList();
            var depAd = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.departmanAd = depAd;
            return View(deger);
        }

        public ActionResult SatisDetay(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var perAd = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + "  " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.personelAd = perAd;
            return View(deger);
        }
    }

}