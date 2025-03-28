using cat.itb.M6NF2Prac.models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.maps
{
    public class providerMap : ClassMap<provider>
    {
        public providerMap()
        {
            Table("provider");
            Id(x => x.id, "id");
            Map(x => x.name, "name");
            Map(x => x.address, "address"); 
            Map(x => x.city, "city");
            Map(x => x.stcode, "stcode");
            Map(x => x.zipcode, "zipcode");
            Map(x => x.area, "area");
            Map(x => x.phone, "phone");
            Map(x => x.ammount, "amount"); 
            Map(x => x.credit, "credit");
            Map(x => x.remark, "remark");

            HasOne(x => x.product)// Relación One-To-One con product
                .Not.LazyLoad()
                .ForeignKey("product") // La clave foránea está en provider
                .Cascade.None(); // Evita eliminaciones en cascada
        }
    }

}
