using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class DonorRepo : IRepo<Donor, int, bool>
    {
        BloodBankEntities db;
        internal DonorRepo()
        {
            db = new BloodBankEntities();
        }

        public bool Add(Donor obj)
        {
            db.Donors.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Donor> Get()
        {
            return db.Donors.ToList();
        }

        public Donor Get(int id)
        {
            return db.Donors.Find(id);
        }

        public bool Update(Donor obj)
        {
            db.Entry(Get(obj.Id)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
