using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DviraciuSurinktuve.Entities;
using DviraciuSurinktuve.Models;
using NHibernate.Criterion;

namespace DviraciuSurinktuve.Controllers
{
    public class SurinktuveController : Controller
    {
        //
        // GET: /Surinktuve/

        public ActionResult Index()
        {
            var session = MvcApplication.SessionFactory.OpenSession();
            var v = session.CreateCriteria(typeof(DetaliųGrupė)).List<DetaliųGrupė>();
            return View(new SurinktuveViewModel(v));
        }

        [HttpPost]
        public ActionResult RodytiParametrus(int detId)
        {
            var session = MvcApplication.SessionFactory.OpenSession();
            string result = "";
            var d = session.CreateCriteria(typeof(Detalė)).Add(
                Restrictions.Eq("Id", detId)
                ).List<Detalė>().FirstOrDefault();
            if (d != null)
            {
                var model = new DetalePartialViewModel(d);

                result = Additional.MvcHelpers.RenderPartialView(this, "Partial/DetalePartialView", model);
            }
            return Content(result, "text/html");
        }

    }
}
