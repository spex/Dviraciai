using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DviraciuSurinktuve.Entities.Mappings
{
    public class ŠablonasMapping : ClassMap<Šablonas>
    {
        public ŠablonasMapping()
        {
            Table("Šablonai");
            Id(x => x.Id).Column("Šablono_Id");
            Map(x => x.Istrinta);
            Map(x => x.Pavadinimas);
            Map(x => x.Sukūrimo_Data);
            HasManyToMany(x => x.Grupės)
            .Cascade.All()
            .Table("Šablonai_Grupės")
            .ParentKeyColumn("Šablono_Id")
            .ChildKeyColumn("Detalių_Grupės_Id");
        }
    }
}