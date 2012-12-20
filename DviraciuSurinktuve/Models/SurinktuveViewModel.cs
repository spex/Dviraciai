using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DviraciuSurinktuve.Entities;

namespace DviraciuSurinktuve.Models{

   public class SurinktuveViewModel {
       public IList<Detalė> Visos{get; set;}

       public SurinktuveViewModel(IList<Detalė> v)
       {
        Visos =  v;
       }

    }
}
