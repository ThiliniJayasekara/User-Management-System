using CrystalDecisions.CrystalReports.Engine;
using System.IO;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;

namespace Login.Controllers
{
    public class SearchController : Controller
    {

        public ActionResult Index()
        {
            inventorymgtEntities dbModel = new inventorymgtEntities();
            return View(dbModel.users.OrderBy(model => model.fname).ToList());
        }

        //public ActionResult Index_Copy()
        //{
        //    inventorymgtEntities dbModel = new inventorymgtEntities();
        //    return View(dbModel.users.OrderBy(model => model.fname).ToList());
        //}



        public ActionResult getUsers()
        {
            using(inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                var users = dbModel.users.OrderBy(model => model.fname).ToList();

                return Json(new { data = users }, JsonRequestBehavior.AllowGet);
            }

        }
        

        public ActionResult viewUser(int id) {

            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                var usr = dbModel.users.Where(a => a.regId == id).FirstOrDefault();
                if (usr != null)
                {
                    return View(usr);

                }
                else
                {
                    return HttpNotFound();
                }
            }

        }

        [HttpPost]
        [ActionName("viewUser")]
        public ActionResult deleteUser(int id) {

            bool status = false;

            using (inventorymgtEntities dbModel = new inventorymgtEntities()) {

                var usr = dbModel.users.Where(a => a.regId == id).FirstOrDefault();
                if(usr != null)
                {
                    dbModel.users.Remove(usr);
                    dbModel.SaveChanges();
                    status = true;
 

                }

                return RedirectToAction("Index");

            }

            

        }

        public ActionResult Report()
        {
            inventorymgtEntities db = new inventorymgtEntities();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/Profile/ProfileReport.rpt")));

            rd.SetDataSource(db.users.Select(p => new
            {
                regId = p.regId,
                fname = p.fname != null ? p.fname : "",
                lname = p.lname != null ? p.lname : "",
                email = p.email != null ? p.email : "",
                age = p.age != null ? p.age : 0,
                ocp = p.ocp != null ? p.ocp : "",
                weight_ = p.weight_ != null ? p.weight_ : 0,
                height = p.height != null ? p.height : 0,
                phone = p.phone != null ? p.phone : "",
                address = p.address != null ? p.address : "",
                shedule = p.shedule != null ? p.shedule : "",
                d_plan = p.d_plan != null ? p.d_plan : "",
                pay_type = p.pay_type != null ? p.pay_type : "",
                gender = p.gender != null ? p.gender : ""


            }).ToList()); ;

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream str = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            str.Seek(0, SeekOrigin.Begin);

            string savedFileName = string.Format("OrderReport_{0}", DateTime.Now);
            return File(str, "application/pdf", savedFileName+".pdf");
        }


    }
}