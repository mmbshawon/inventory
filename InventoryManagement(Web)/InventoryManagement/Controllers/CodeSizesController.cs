using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class CodeSizesController : Controller
    {
        // GET: CodeSizes
        public ActionResult Index()
        {
            return View();
        }
    }
}