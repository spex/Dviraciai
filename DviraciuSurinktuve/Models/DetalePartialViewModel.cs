using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DviraciuSurinktuve.Entities;

namespace DviraciuSurinktuve.Models
{
    public class DetalePartialViewModel
    {
        public Detalė detalė;
        public DetalePartialViewModel(Detalė d)
        {
            detalė = d;
        }
        public DetalePartialViewModel()
        {
         
        }

    }
}