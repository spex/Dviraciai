using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DviraciuSurinktuve.Entities.Mappings
{
    public class DetalėMapping : ClassMap<Detalė>
    {
        public DetalėMapping()
        {
            Table("Detalės");
            Id(x => x.Id).Column("Detalė_ID");
            Map(x => x.Apibūdinimas);
            Map(x => x.Ar_Aktyvi);
            Map(x => x.Pavadinimas);
            Map(x => x.Paveikslėlio_URL);
            Map(x => x.Sukūrimo_Data);
            References(x => x.Grupė).Column("Grupės_Id");
            HasManyToMany(x => x.Jungtys)
            .Cascade.All()
            .Table("Detalės_Jungtys")
            .ParentKeyColumn("Jungties_Id")
            .ChildKeyColumn("Detalės_Id");

        }
    }
}