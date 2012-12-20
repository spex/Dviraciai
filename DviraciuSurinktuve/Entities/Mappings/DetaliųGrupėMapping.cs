using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DviraciuSurinktuve.Entities.Mappings
{
    public class DetaliųGrupėMapping : ClassMap<DetaliųGrupė> 
    {
        public DetaliųGrupėMapping()
        {
            Table("Detalių_Grupės");
            Id(x => x.Id).Column("Detalių_Grupė_ID");
            Map(x => x.Apibūdinimas);
            Map(x => x.Ar_Aktyvi);
            Map(x => x.Pavadinimas);
            Map(x => x.Paveikslėlio_URL);
            Map(x => x.Sukūrimo_Data);
            HasMany<Detalė>(x => x.Detalės).KeyColumn("Grupės_Id");
        }
    }
}