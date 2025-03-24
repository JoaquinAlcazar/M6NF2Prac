using cat.itb.M6NF2Prac.models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.maps
{
    public class orderprodMap : ClassMap<orderprod>
    {
        public orderprodMap()
        {
            Table("orderprod");
            Id(x => x.id, "id");
            Map(x => x.orderdate, "orderdate");
            Map(x => x.amount, "amount");
            Map(x => x.deliverydate, "deliverydate");
            Map(x => x.cost, "cost");

            References(x => x.product, "product") // Relación Many-To-One con product
                .Not.Nullable() 
                .Fetch.Join()
                .Cascade.None(); 

            References(x => x.client, "client") // Relación Many-To-One con client
                .Not.Nullable()
                .Fetch.Join()
                .Cascade.None(); 
        }
    }

}
