using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using ZeroHunger.DB;
using ZeroHunger.Models;
using ZeroHunger.Repo;

namespace ZeroHunger.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);
            ViewBag.Admin = admin;

            var requests = DistributeRepo.Get();
            var foods = new List<List<DistributeDetailModel>>();

            foods.Add(DistributeDetailsRepo.Get());

            ViewBag.Foods = foods;
            ViewBag.Employees = EmployeeRepo.Get();
            ViewBag.Areas = AreaRepo.Get();
            ViewBag.Requests = requests;
            return View();
        }

        [HttpPost]
        public ActionResult Index(DistributeRequestModel data, string Email)
        {
            if(data.EmployeeId != null && data.Id != 0)
            {
                DistributeRepo.Update(data);
                var info = new MailData();
                info.Email = Email;
                WorkAssignMail.Mail(info);
            }

            return RedirectToAction("Index");
        }

        public ActionResult ViewProfile()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);
            return View(admin);
        }

        [HttpGet]
        public ActionResult Setting()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult Setting(AdminData admin, HttpPostedFileBase Image)
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var old_admin = AdminRepo.Get(user.Id);
            if (ModelState.IsValid)
            {
                if (Image == null)
                {
                    ViewBag.Error = 1;
                    ViewBag.ErrorMessage = "Please Select an Image";
                }
                else
                {
                    string path = Server.MapPath("~/Assets/img/profiles/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    Image.SaveAs(path + Path.GetFileName(Image.FileName));
                    var db_path = "/Assets/img/profiles/" + Image.FileName;
                    admin.Image = db_path;


                }
                AdminRepo.Update(admin);
                return RedirectToAction("ViewProfile");

            }
            admin.Image = old_admin.Image;
            return View(admin);
        }

        public ActionResult EmpoyeeList()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);

            ViewBag.Areas = AreaRepo.Get();
            ViewBag.Employees = EmployeeRepo.Get();
            return View(admin);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            ViewBag.admin = AdminRepo.Get(user.Id);
            ViewBag.Areas = AreaRepo.Get();

            var employee = new EmployeeDataRegistration();

            return View(employee);
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeDataRegistration employee)
        {
            if (ModelState.IsValid)
            {
                string password = RendomStringGenerator.RandomString(6);
                var newUser = new UserModel();
                newUser.Email = employee.Email;
                newUser.Password = password;
                newUser.Type = 2;

                var addeddNewUser = UserRepo.Create(newUser);

                var newemployee = new EmployeeModel();
                newemployee.Name = employee.Name;
                newemployee.Image = "/Assets/img/profiles/avatar-14.png";
                newemployee.Address = employee.Address;
                newemployee.DOB = DateTime.Now;
                newemployee.AreaId = employee.AreaId;
                newemployee.UserId = addeddNewUser.Id;

                EmployeeRepo.Create(newemployee);

                var mail = new MailData()
                {
                    Email = newUser.Email,
                    Name = employee.Name,
                    Subject = "Registration Confermation",
                    Body = @"Your password of Zero Hunger is: " + password,
                };

                EmployeeRegistrationConfirmMail.Mail(mail);
                
                return RedirectToAction("EmpoyeeList");
            }
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            ViewBag.admin = AdminRepo.Get(user.Id);
            ViewBag.Areas = AreaRepo.Get();
            return View(employee);
        }
        
        public ActionResult RestaurantList()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);

            ViewBag.Areas = AreaRepo.Get();
            var requests = DistributeRepo.Get();
            ViewBag.Requests = requests;

            ViewBag.Restaurants = RestaurantRepo.Get();
          
            return View(admin);
        }

        [HttpGet]
        public ActionResult AreaList()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);
            ViewBag.Admin = admin;

            ViewBag.Areas = AreaRepo.Get();
            return View();
        }

        [HttpPost]
        public ActionResult AreaList(AreaModel new_area)
        {
            if (ModelState.IsValid)
            {
                AreaRepo.Create(new_area);
                return RedirectToAction("AreaList");
            }
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);
            ViewBag.Admin = admin;

            ViewBag.Areas = AreaRepo.Get();
            return View(new_area);
        }
    }
}