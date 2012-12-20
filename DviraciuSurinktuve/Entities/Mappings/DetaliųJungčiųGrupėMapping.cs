using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DviraciuSurinktuve.Entities.Mappings
{
    public class DetaliųJungčiųGrupėMapping : ClassMap<DetaliųJungčiųGrupė> 
    {
        public DetaliųJungčiųGrupėMapping()
        {
            Table("Detalių_Jungčių_Grupės");
            Id(x => x.Id).Column("Jungčių_Grupės_ID");
            Map(x => x.Apibūdinimas);
            Map(x => x.Ar_Aktyvi);
            Map(x => x.Pavadinimas);
            Map(x => x.Paveikslėlio_URL);
            Map(x => x.Sukūrimo_Data);
            HasMany<DetaliųJungtis>(x => x.Jungtys).KeyColumn("Grupės_Id");
        }
    }
}