using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_1.Controllers
{
    public class CvController : Controller
    {
        // GET: Cv
        public ActionResult Index()
        {
            dynamic info = new Dictionary<string, string>(){
                {"Name", "Md. Mahim Talukder"},
                {"ID", "19-41621-3"},
                {"Department", "CS"},
                {"Image", "~/images/mahim.png"}
            };
            ViewBag.info = info;
       
            return View();
        }

        public ActionResult Education()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Reference()
        {
            List<Dictionary<string, string>> info_list = new List<Dictionary<string, string>>();

            Dictionary<string, string> info = new Dictionary<string, string>();

            info.Add("name", "RASHIDUL HASAN NABIL");
            info.Add("post", "Lecturer");
            info.Add("department", "Faculty of Science and Technology");
            info.Add("institution", "American International University-Bangladesh (AIUB)");
            info.Add("email", "rashidul@aiub.edu");

            info_list.Add(new Dictionary<string, string>(info));

            info["name"] = "MD. NAZMUL HOSSAIN";
            info["post"] = "Lecturer";
            info["department"] = "Faculty of Science and Technology";
            info["institution"] = "American International University-Bangladesh (AIUB)";
            info["email"] = "nazmul@aiub.edu";

            info_list.Add(new Dictionary<string, string>(info));

            ViewBag.info_list = info_list;

            return View();
        }
    }
}