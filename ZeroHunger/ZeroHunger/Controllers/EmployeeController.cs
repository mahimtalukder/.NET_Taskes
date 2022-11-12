using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ZeroHunger.DB;
using ZeroHunger.Models;
using ZeroHunger.Repo;

namespace ZeroHunger.Controllers
{
    [EmployeeAccess]
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            string json = (string)Session["employee"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var employee = EmployeeRepo.Get(user.Id);
            ViewBag.Employee = employee;
            var requests = DistributeRepo.EmpGet(employee.Id);
            var foods = new List<List<DistributeDetailModel>>();

            foreach (var item in requests)
            {
                foods.Add(DistributeDetailsRepo.Get(item.Id));
            }

            ViewBag.Foods = foods;
            ViewBag.Restaurants = RestaurantRepo.Get();
            return View(requests);
        }
        [HttpPost]
        public ActionResult Index(DistributeRequestModel data)
        {
            string json = (string)Session["employee"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var employee = EmployeeRepo.Get(user.Id);
            if (data.Id != 0)
            {
                data.EmployeeId = employee.Id;
                DistributeRepo.UpdateStatus(data);
            }

            return RedirectToAction("Index");
        }

        public ActionResult ViewProfile()
        {
            string json = (string)Session["employee"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var employee = EmployeeRepo.Get(user.Id);

            var area = AreaRepo.Get();
            ViewBag.Area = area;
            return View(employee);
        }

        [HttpGet]
        public ActionResult Setting()
        {
            string json = (string)Session["employee"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var employee = EmployeeRepo.Get(user.Id);

            var area = AreaRepo.Get();
            ViewBag.Area = area;
            return View(employee);
        }

        [HttpPost]
        public ActionResult Setting(EmployeeData employee)
        {
            string json = (string)Session["employee"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var old_employee = EmployeeRepo.Get(user.Id);
            var area = AreaRepo.Get();
            ViewBag.Area = area;
            if (ModelState.IsValid)
            {
                EmployeeRepo.Update(employee);
                return RedirectToAction("ViewProfile");

            }
            employee.Image = old_employee.Image;
            return View(employee);
        }
    }
}