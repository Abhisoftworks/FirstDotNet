using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "MVC Application created by Abhishek and Aditya .";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult logintrail()
        {
            ViewBag.Message = "Your logintrail page.";

            return View();
        }

        public string save(string name,string id,DateTime date,string gender) 
        {
            
            Detail obj = new Detail();
            string str =obj.save(name,id,date,gender);
            return str;
        }

        public JsonResult GetDetails()
        {

            Detail obj = new Detail();
            DataTable dt = obj.GetDetails();
            List<Dictionary<string, object>> lst = obj.GetTableRows(dt);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public string deleteDetails(string id)
        {

            Detail obj = new Detail();
            string str = obj.deleteDetails(id);
            return str;
        }


        public JsonResult editDetails(string id)
        {

            Detail obj = new Detail();
            DataTable dt = obj.editDetails(id);
            List<Dictionary<string, object>> lst = obj.GetTableRows(dt);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}
