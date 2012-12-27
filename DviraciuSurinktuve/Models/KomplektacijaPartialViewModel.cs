using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DviraciuSurinktuve.Entities;

namespace DviraciuSurinktuve.Models
{
    public class KomplektacijaPartialViewModel
    {
        public Komplektacija komplektacija;
        public KomplektacijaPartialViewModel(Komplektacija k)
        {
            komplektacija = k;
        }
        public KomplektacijaPartialViewModel()
        {
         
        }

    }
}