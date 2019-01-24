using InvemtoryManagement.DatabaseContext;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class CodeFabricsController : Controller
    {
        InventoryDbContext db = new InventoryDbContext();
        // GET: CodeFabrics
        public ActionResult Index()
        {
            return View(db.CodeFabrics.ToList());
        }
        [HttpPost]
        public ActionResult Create(CodeFabrics codeFabrics)
        {
            string message = "Saved Successfully";
            bool status = true;
            db.CodeFabrics.Add(codeFabrics);
            db.SaveChanges();
            return Json(new { status = status, message = message, id = db.CodeFabrics.Max(x => x.Id) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int Id)
        {
            var fabric = db.CodeFabrics.Where(x => x.Id == Id).FirstOrDefault();
            db.CodeFabrics.Remove(fabric);
            db.SaveChanges();
            string message = "Reocord has been deleted successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFabric(int id)
        {
            CodeFabrics data = new CodeFabrics();
            var getFabric = db.CodeFabrics.Where(x => x.Id == id).FirstOrDefault();
            data.Id = getFabric.Id;
            data.FabricsName = getFabric.FabricsName;
            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateFabric(CodeFabrics model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            string message = "Recored has been updated seccesfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}