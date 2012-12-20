using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate;
using FluentNHibernate.Cfg.Db;


public class OdbcConfiguration : 
    PersistenceConfiguration<OdbcConfiguration, 
        FluentNHibernate.Cfg.Db.OdbcConnectionStringBuilder>
{
    protected OdbcConfiguration()
    {
        Driver<NHibernate.Driver.OdbcDriver>();
    }

    public static OdbcConfiguration AccessDialect // <-- insert any name here
    {
        get
        {
            // insert the dialect you want to use
            return new OdbcConfiguration().Dialect<NHibernate.Dialect.MsSql2008Dialect>();
        }
    }
} 