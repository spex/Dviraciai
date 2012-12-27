using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DviraciuSurinktuve.Entities;
using DviraciuSurinktuve.Models;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate;

namespace DviraciuSurinktuve.Controllers
{
    public partial class SurinktuveController : Controller
    {
        //
        // GET: /Surinktuve/
        private NHibernate.ISession _session;
        private Komplektacija _dabartinėKomplektacija;

        public NHibernate.ISession session
        {
            get
            {
                if (_session == null) _session = MvcApplication.SessionFactory.OpenSession();
                return _session;
            }
            set { _session = value; }
        }

        public Komplektacija dabartinėKomplektacija
        {
            get
            {
                try { _dabartinėKomplektacija = (Komplektacija)Session["DabartineKomplektacija"]; }
                catch (Exception) { }
                if (_dabartinėKomplektacija == null)
                {
                    _dabartinėKomplektacija = new Komplektacija();
                    _dabartinėKomplektacija.Pavadinimas = "Nauja Kompl";
                    _dabartinėKomplektacija.Detalės = new List<Detalė>();
                    _dabartinėKomplektacija.šablonas = session.CreateCriteria(typeof(Šablonas)).Add(
                Restrictions.Eq("Id", 1)
                ).List<Šablonas>().FirstOrDefault();
                    Session["DabartineKomplektacija"] = _dabartinėKomplektacija;
                }


                return _dabartinėKomplektacija;
            }
            set
            {
                _dabartinėKomplektacija = value;
                Session["DabartineKomplektacija"] = _dabartinėKomplektacija;
            }
        }






        public virtual ActionResult Index()
        {

            var v = session.CreateCriteria(typeof(DetaliųGrupė)).List<DetaliųGrupė>();
            return View(new SurinktuveViewModel() { VisosGrupės = v, KomplektacijaModel = new KomplektacijaPartialViewModel(dabartinėKomplektacija) });
        }

        [HttpPost]
        public virtual ActionResult RodytiParametrus(int detId)
        {
            string result = "";
            var d = session.CreateCriteria(typeof(Detalė)).Add(
                Restrictions.Eq("Id", detId)
                ).List<Detalė>().FirstOrDefault();
            if (d != null)
            {
                var model = new DetalePartialViewModel(d);

                result = Additional.MvcHelpers.RenderPartialView(this, MVC.Surinktuve.Views.Partial.DetalePartialView, model);
            }
            return Content(result, "text/html");
        }

        public virtual ActionResult GautiKomplektacija()
        {


            return PartialView(MVC.Surinktuve.Views.Partial.KomplektacijaPartialView, new KomplektacijaPartialViewModel() { komplektacija = dabartinėKomplektacija });
        }
        public virtual ActionResult PridetiDetaleKomplektacijai(int detId)
        {
            string result = "";
            var d = session.CreateCriteria(typeof(Detalė)).Add(
                Restrictions.Eq("Id", detId)
                ).List<Detalė>().FirstOrDefault();
            if (d != null)
            {
                dabartinėKomplektacija.Detalės.Add(d);
                result = Additional.MvcHelpers.RenderPartialView(this, MVC.Surinktuve.Views.Partial.KomplektacijaPartialView, new KomplektacijaPartialViewModel() { komplektacija = dabartinėKomplektacija });
                using (ITransaction trans = session.BeginTransaction())
                {
                    session.SaveOrUpdate(dabartinėKomplektacija); 
                    trans.Commit();  
                }


                session.Close();

            }
            return Content(result, "text/html");
        }

    }
}
