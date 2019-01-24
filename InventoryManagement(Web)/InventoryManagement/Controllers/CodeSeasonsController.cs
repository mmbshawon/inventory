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
    public class CodeSeasonsController : Controller
    {
        InventoryDbContext db = new InventoryDbContext();

        // GET: CodeSeasons
        public ActionResult Index()
        {
            return View(db.CodeSeasons.ToList());
        }

        [HttpPost]
        public ActionResult Create(CodeSeasons codeSeasons)
        {
            string message = "Saved Successfully";
            bool status = true;
            db.CodeSeasons.Add(codeSeasons);
            db.SaveChanges();
            return Json(new { status = status, message = message, id = db.CodeSeasons.Max(x => x.Id) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int Id)
        {
            var season = db.CodeSeasons.Where(x => x.Id == Id).FirstOrDefault();
            db.CodeSeasons.Remove(season);
            db.SaveChanges();
            string message = "Reocord has been deleted successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSeason(int id)
        {
            CodeSeasons data = new CodeSeasons();
            var getSeason = db.CodeSeasons.Where(x => x.Id == id).FirstOrDefault();
            data.Id = getSeason.Id;
            data.SeasonsName = getSeason.SeasonsName;
            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateSeason(CodeSeasons model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            string message = "Recored has been updated seccesfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }


    }
}