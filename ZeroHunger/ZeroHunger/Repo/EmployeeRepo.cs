using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.DB;
using ZeroHunger.Models;

namespace ZeroHunger.Repo
{
    public class EmployeeRepo
    {
        public static List<EmployeeData> Get()
        {
            var employees = new List<EmployeeData>();
            var db = new ZeroHungerEntities();
            var db_users = db.Users.ToList();

            foreach (var employee in db.Employees)
            {
                var user = (from us in db_users
                            where us.Id == employee.UserId
                            select us).FirstOrDefault();
                employees.Add(new EmployeeData()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Image = employee.Image,
                    Address = employee.Address,
                    UserId = employee.UserId,
                    AreaId = employee.AreaId,
                    Email = user.Email,
                });
            }

            return employees;
        }

        public static EmployeeData Get(int UserId)
        {
            var db = new ZeroHungerEntities();
            var employee = new EmployeeData();
            var db_employee = (from ad in db.Employees
                            where ad.UserId == UserId
                            select ad).SingleOrDefault();
            var db_user = (from ad in db.Users
                           where ad.Id == UserId
                           select ad).SingleOrDefault();

            employee.Id = db_employee.Id;
            employee.Name = db_employee.Name;
            employee.Email = db_user.Email;
            employee.Password = db_user.Password;
            employee.Image = db_employee.Image;
            employee.DOB = db_employee.DOB;
            employee.Address = db_employee.Address;
            employee.UserId = db_employee.UserId;
            employee.AreaId = db_employee.AreaId;

            return employee;

        }

        public static string Update(EmployeeData employee)
        {
            var db = new ZeroHungerEntities();
            var db_employee = (from emp in db.Employees
                            where emp.UserId == employee.UserId
                            select emp).SingleOrDefault();
            var db_user = (from ad in db.Users
                           where ad.Id == employee.UserId
                           select ad).SingleOrDefault();
            
            db_user.Email = employee.Email;
            db_employee.Name = employee.Name;
            db_employee.Address = employee.Address;
            db_employee.DOB = employee.DOB;
            db_employee.AreaId = employee.AreaId;
            db.SaveChanges();

            return "updated";

        }

        public static void Create(EmployeeModel employee)
        {
            var db = new ZeroHungerEntities();
            var newUser = db.Employees.Add(new Employee()
            {
                Name = employee.Name,
                Image = employee.Image,
                DOB = employee.DOB,
                Address = employee.Address,
                AreaId = employee.AreaId,
                UserId = employee.UserId,

            });
            db.SaveChanges();
        }
    }
}