using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using ZeroHunger.DB;
using ZeroHunger.Models;

namespace ZeroHunger.Repo
{
    public class AreaRepo
    {
        public static List<AreaModel> Get()
        {
            var areas = new List<AreaModel>();
            var db = new ZeroHungerEntities();

            foreach(var area in db.Areas)
            {
                areas.Add(new AreaModel()
                {
                    Id = area.Id,
                    AreaName = area.AreaName
                });
            }
            return areas;
        }

        public static bool IsUnique(string AreaName, int Id)
        {
            var db = new ZeroHungerEntities();
            var area = (from ar in db.Areas
                        where ar.AreaName == AreaName && ar.Id != Id
                        select ar).FirstOrDefault();

            if(area == null)
            {
                return true;
            }
            return false;
        }

        public static void Create(AreaModel area)
        {
            var db = new ZeroHungerEntities();
            var newArea = new Area()
            {
                AreaName = area.AreaName,
            };
            db.Areas.Add(newArea);
            db.SaveChanges();
        }
    }
}