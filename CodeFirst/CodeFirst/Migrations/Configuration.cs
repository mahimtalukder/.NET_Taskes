namespace CodeFirst.Migrations
{
    using CodeFirst.EF.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Xml.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst.EF.UMSDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirst.EF.UMSDBContext context)
        {
            List<Department> depts = new List<Department>();
            for (int i=1; i <= 1000; i++)
                {
                depts.Add(new Department()
                {
                    Id = i,

                    Name = Guid.NewGuid().ToString().Substring(0, 4) 

                });
            }
            context.Departments.AddOrUpdate(depts.ToArray());
               
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
