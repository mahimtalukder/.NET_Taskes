using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IRepo<CLASS,ID>
    {
        void Add(CLASS obj);
        CLASS Get(ID Id);
    }

}
