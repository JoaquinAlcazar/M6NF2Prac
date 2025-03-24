using cat.itb.M6NF2Prac.models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.maps
{
    public class salespersonMap : ClassMap<salesperson>
    {
        public salespersonMap()
        {
            Table("salesperson");
            Id(x => x.id, "id");
            Map(x => x.surname, "surname");
            Map(x => x.job, "job");
            Map(x => x.startdate, "startdate");
            Map(x => x.salary, "salary");
            Map(x => x.commission, "commission");
            Map(x => x.dep, "dep");

            HasMany(x => x.Products) // Relación One-To-Many con product
                .KeyColumn("salesp") // Clave foránea en la tabla product
                .Inverse() 
                .AsSet()
                .Cascade.All();
        }
    }

}
