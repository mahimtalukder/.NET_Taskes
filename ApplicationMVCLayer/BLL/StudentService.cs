using BLL.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentService
    {
        public static List<StudentModel> Get()
        {
            var list = new List<StudentModel>();
            var data = StudentRepo.Get();
            foreach (var item in data)
            {
                list.Add(new StudentModel() { Id = item.Id, Name = item.Name });
            }

            return list;
        }
    }
}
