using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DviraciuSurinktuve.Entities
{
    public class Komplektacija
    {
        public virtual int Id { get; set; }
        public virtual string Pavadinimas { get; set; }
        public virtual IList<Detalė> Detalės { get; set; }
        public virtual DateTime Sukūrimo_Data { get; set; }
        public virtual bool Istrinta { get; set; }
        public virtual Šablonas šablonas { get; set; }
    }
}