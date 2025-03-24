using cat.itb.M6NF2Prac.models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.maps
{
    public class productMap : ClassMap<product>
    {
        public productMap()
        {
            Table("product");
            Id(x => x.id, "id");
            Map(x => x.code, "code");
            Map(x => x.description, "description");
            Map(x => x.currentstock, "currentstock");
            Map(x => x.minstock, "minstock");
            Map(x => x.price, "price");

            References(x => x.salesp, "salesp") // Clave foránea Many-To-One con salesperson
                .Not.Nullable(); // Un producto siempre debe tener un vendedor

            HasOne(x => x.provider) // Relación One-To-One con provider
                .ForeignKey("product") 
                .Cascade.All();

            HasMany(x => x.Orders) // Relación One-To-Many con orderprod
                .KeyColumn("product") // Clave foránea en ORDERPROD
                .Inverse() 
                .AsSet()
                .Cascade.All(); 
        }
    }

}
