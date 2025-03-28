using cat.itb.M6NF2Prac.models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cat.itb.M6NF2Prac.maps
{
    public class clientMap : ClassMap<client>
    {
        public clientMap()
        {
            Table("client");
            Id(x => x.id, "id");
            Map(x => x.code, "code");
            Map(x => x.name, "name");
            Map(x => x.credit, "credit");

            HasMany(x => x.Orders) // Relación One-To-Many con ORDERPROD
                .KeyColumn("client") // Clave foránea en ORDERPROD
                .Inverse() 
                .AsSet()
                .Cascade.All()
                .Fetch.Join(); 
        }
    }

}
