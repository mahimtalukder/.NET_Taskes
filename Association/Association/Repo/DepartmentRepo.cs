using Association.DB;
using Association.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association.Repo
{
    public class DepartmentRepo
    {
        public static List<DepartmentModel> Get()
        {
            var db = new UMSEntities();
            var departments = new List<DepartmentModel>();

            foreach (var department in db.Departments)
            {
                departments.Add(new DepartmentModel()
                {
                    Id = department.Id,
                    Name = department.Name,
                });
            }

            return departments;
        }

        public static DepartmentModel Get(int Id)
        {
            var db = new UMSEntities();
            var department = (from st in db.Departments
                           where Id == st.Id
                           select st).SingleOrDefault();

            var departments = new DepartmentModel()
            {
                Id = department.Id,
                Name = department.Name,

            };

            return departments;

        }

        public static void Create(DepartmentModel st)
        {
            var department = new Department();
            department.Id = st.Id;
            department.Name = st.Name;
            var db = new UMSEntities();
            db.Departments.Add(department);
            db.SaveChanges();

        }
    }
}