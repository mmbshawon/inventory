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
    public class CodeColorsController : Controller
    {
        InventoryDbContext db = new InventoryDbContext();
        // GET: CodeColors
        public ActionResult Index()
        {
            return View(db.CodeColors.ToList());
        }
        [HttpPost]
        public ActionResult Create(CodeColors codeColors)
        {
            string message = "Saved Successfully";
            bool status = true;
            db.CodeColors.Add(codeColors);
            db.SaveChanges();
            return Json(new { status = status, message = message, id = db.CodeColors.Max(x => x.Id) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int Id)
        {
            var color = db.CodeColors.Where(x => x.Id == Id).FirstOrDefault();
            db.CodeColors.Remove(color);
            db.SaveChanges();
            string message = "Reocord has been deleted successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetColor(int id)
        {
            CodeColors data = new CodeColors();
            var getColor = db.CodeColors.Where(x => x.Id == id).FirstOrDefault();
            data.Id = getColor.Id;
            data.ColorsName = getColor.ColorsName;
            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateColor(CodeColors model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            string message = "Recored has been updated seccesfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}