using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DviraciuSurinktuve.Entities
{
    public class DetaliųGrupė
    {
        public virtual int Id { get; set; }
        public virtual string Pavadinimas { get; set; }
        public virtual string Apibūdinimas { get; set; }
        public virtual DateTime Sukūrimo_Data { get; set; }
        public virtual bool Ar_Aktyvi { get; set; }
        public virtual string Paveikslėlio_URL { get; set; }

        public virtual IList<Detalė>  Detalės {get; set;}

    }
}