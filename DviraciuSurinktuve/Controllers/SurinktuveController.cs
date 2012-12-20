using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DviraciuSurinktuve.Entities;
using DviraciuSurinktuve.Models;

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

    }
}
