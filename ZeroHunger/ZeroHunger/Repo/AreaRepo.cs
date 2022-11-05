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
    }
}