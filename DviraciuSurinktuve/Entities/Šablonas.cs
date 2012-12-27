using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DviraciuSurinktuve.Entities
{
    public class Šablonas
    {
        public virtual int Id { get; set; }
        public virtual string Pavadinimas { get; set; }
        public virtual string Apibūdinimas { get; set; }
        public virtual IList<DetaliųGrupė> Grupės { get; set; }
        public virtual DateTime Sukūrimo_Data { get; set; }
        public virtual bool Istrinta { get; set; }
    }
}