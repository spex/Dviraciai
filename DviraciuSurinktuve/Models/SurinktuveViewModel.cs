using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DviraciuSurinktuve.Entities;

namespace DviraciuSurinktuve.Models{

   public class SurinktuveViewModel {
       public IList<DetaliųGrupė> VisosGrupės { get; set; }
       public KomplektacijaPartialViewModel KomplektacijaModel { get; set; }
       public SurinktuveViewModel()
       {
       }

    }
}
