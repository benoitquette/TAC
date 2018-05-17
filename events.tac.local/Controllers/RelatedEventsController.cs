using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using events.tac.local.Business;

namespace events.tac.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        private RelatedEventsProvider provider;

        public RelatedEventsController() : this(new RelatedEventsProvider()) { }

        public RelatedEventsController(RelatedEventsProvider provider)
        {
            this.provider = provider;
        }

        // GET: RelatedEvents
        public ActionResult Index()
        {
            return View(this.provider.GetRelatedEvents());
        }
    }
}