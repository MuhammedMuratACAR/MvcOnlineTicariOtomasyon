using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        Context c = new Context();  
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafik = new Chart(600,600);
            grafik.AddTitle(text: "Kategoriler ve Ürün Sayıları");
            grafik.AddLegend(title: "Stok");
            grafik.AddSeries(
                name: "Veriler",
                chartType: "Doughnut",//Bubble(kare kabarcık),Pie(daire),Doughnut(ortası boş daire),Area(bölge),Bar(soldan sağa)
                xValue: new[] { "Beyaz Eşya", "Mobilya", "Bilgisayar", "Küçük Ev Aletleri" },
                yValues: new[] { 500, 250, 340, 620 }
                );
            grafik.Write();
            return File(grafik.ToWebImage().GetBytes(),"image/jpeg");
        }

        public ActionResult Index3()
        {
            ArrayList xValue = new ArrayList();
            ArrayList YValue = new ArrayList();
            var urun = c.Uruns.ToList();
            urun.ToList().ForEach(x => xValue.Add(x.UrunAd));
            urun.ToList().ForEach(y => YValue.Add(y.Stok));
            var grafik = new Chart(600, 600)
            .AddTitle(text: "Ürün Stok")
            .AddSeries(
                name: "Stok",
                //chartType: "Column",
                chartType: "Pie",
                xValue: xValue,
                yValues: YValue
                )
           .Write();
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<GrafikSinif> UrunListesi()
        {
            List<GrafikSinif> snf = new List<GrafikSinif>();
            snf.Add(new GrafikSinif()
            {
                GrafikUrunAd="Bilgisayar",
                GrafikStok=120
            });
            snf.Add(new GrafikSinif()
            {
                GrafikUrunAd = "Beyaz Eşya",
                GrafikStok = 150
            });
            snf.Add(new GrafikSinif()
            {
                GrafikUrunAd = "Mobilya",
                GrafikStok = 70
            });
            snf.Add(new GrafikSinif()
            {
                GrafikUrunAd = "Küçük Ev Aletleri",
                GrafikStok = 180
            });
            snf.Add(new GrafikSinif()
            {
                GrafikUrunAd = "Mobil Cihazlar",
                GrafikStok = 90
            });
            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<GrafikSinif2> UrunListesi2()
        {
            List<GrafikSinif2> snf = new List<GrafikSinif2>();
            using (var c=new Context())
            {
                snf = c.Uruns.Select(x => new GrafikSinif2
                {
                    GrafikUrunAd = x.UrunAd,
                    GrafikStok = x.Stok

                }).ToList();
            }
                return snf;
        }
    }
}