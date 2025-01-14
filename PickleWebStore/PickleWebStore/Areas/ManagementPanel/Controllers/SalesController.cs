using PickleWebStore.Areas.ManagementPanel.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickleWebStore.Areas.ManagementPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class SalesController : Controller
    {
        private PickleWebDBModel db = new PickleWebDBModel();
        // GET: ManagementPanel/Sales
        public ActionResult Index()
        {
            return View();
        }
    }
}