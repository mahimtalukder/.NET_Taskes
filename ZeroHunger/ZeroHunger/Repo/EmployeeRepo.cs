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
        public static List<EmployeeModel> Get()
        {
            var employees = new List<EmployeeModel>();
            var db = new ZeroHungerEntities();

            foreach (var employee in db.Employees)
            {
                employees.Add(new EmployeeModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Image = employee.Image,
                    Address = employee.Address,
                    UserId = employee.UserId,
                    AreaId = employee.AreaId
                });
            }

            return employees;
        }

        public static EmployeeModel Get(int UserId)
        {
            var db = new ZeroHungerEntities();
            var employee = new EmployeeModel();
            var db_employee = (from emp in db.Employees
                            where emp.UserId == UserId
                            select emp).SingleOrDefault();

            employee.Id = db_employee.Id;
            employee.Name = db_employee.Name;
            employee.Image = db_employee.Image;
            employee.Address = db_employee.Address;
            employee.UserId = db_employee.UserId;
            employee.AreaId = db_employee.AreaId;

            return employee;

        }

        public static void Create(EmployeeModel employee)
        {

        }
    }
}