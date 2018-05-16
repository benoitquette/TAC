using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using events.tac.local.Business;

namespace events.tac.local.Controllers
{
    public class NavigationController : Controller
    {
        private NavigationBuilder builder;

        public NavigationController(): this(new NavigationBuilder()) { }

        public NavigationController(NavigationBuilder builder)
        {
            this.builder = builder;
        }

        // GET: Navigation
        public ActionResult Index()
        {
            return View(builder.Build());
        }
    }
}