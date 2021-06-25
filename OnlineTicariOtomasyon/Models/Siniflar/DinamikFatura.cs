using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class DinamikFatura
    {
        public IEnumerable<Faturalar> Fatura { get; set; }
        public IEnumerable<FaturaKalem> FaturaKalem { get; set; }
    }
}