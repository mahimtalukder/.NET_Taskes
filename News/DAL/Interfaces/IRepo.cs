using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IRepo<CLASS, ID>
    {
        List<CLASS> Get();
        CLASS Get(ID Id);
        void Create(CLASS data);
        CLASS Update(CLASS data);
        void Delete(ID Id);

    }
}
