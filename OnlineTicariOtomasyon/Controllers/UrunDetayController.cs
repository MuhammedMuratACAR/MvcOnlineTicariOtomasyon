using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {

        //    public IEnumerable<Urun> Deger1 { get; set; }
        //     public IEnumerable<Detay> Deger2 { get; set; }

        //    Class1 cs = new Class1();
        //cs.Deger1=.Uruns.Where(x=>x.UrunID==1).ToList();
        //cs.Deger2=.Detays.cs);

        var degerler = c.Uruns.Where(x=>x.UrunID==1).ToList();
            return View(degerler);
        }
    }
}