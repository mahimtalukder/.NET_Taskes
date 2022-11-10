using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentRepo
    {
        public static List<Student> Get()
        {
            var list = new List<Student>();
            for(int i = 0; i < 10; i++)
            {
                list.Add(new Student(){ Id = i, Name = "Student"+i});
            }
            return list;
        }
    }
}
