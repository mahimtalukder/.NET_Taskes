using Association.DB;
using Association.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Association.Repo
{
    public class StudentRepo
    {
        //public static List<>
        public static List<StudentModel> Get()
        {
            var db = new UMSEntities();
            var students = new List<StudentModel>();

            foreach(var student in db.Students)
            {
                students.Add(new StudentModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    DepartmentId = student.DepartmentId,
                    Dob = student.Dob,
                    StudentId = student.StudentId
                });
            }

            return students;
        }

        public static StudentModel Get(int Id)
        {
            var db = new UMSEntities();
            var student = (from st in db.Students
                           where Id == st.Id
                           select st).SingleOrDefault();

            var students = new StudentModel()
            {
                Id = student.Id,
                Name = student.Name,
                DepartmentId = student.DepartmentId,
                Dob = student.Dob,
                StudentId = student.StudentId

            };

            return students;

        }

        public static void Create(StudentModel st)
        {
            var student = new Student();
            student.Id = st.Id;
            student.Name = st.Name;
            student.DepartmentId = st.DepartmentId;
            student.Dob = st.Dob;
            student.StudentId = st.StudentId;
            var db = new UMSEntities();
            db.Students.Add(student);
            db.SaveChanges();

        }
    }
}