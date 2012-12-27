using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DviraciuSurinktuve.Entities.Mappings
{
    public class KomplektacijaMapping : ClassMap<Komplektacija>
    {
        public KomplektacijaMapping()
        {
            Table("Komplektacijos");
            Id(x => x.Id).Column("Kompl_Id");
            Map(x => x.Istrinta);
            Map(x => x.Pavadinimas);
            Map(x => x.Sukūrimo_Data);
            HasManyToMany<Detalė>(x => x.Detalės).AsBag()
                .Table("Komplektacijos_Detalės")
            .ChildKeyColumn("Detalės_Id")
            .ParentKeyColumn("Komplektacijos_Id")
            .Cascade.AllDeleteOrphan(); 

            References(x => x.šablonas).Column("Šablono_Id");
        }
    }
}