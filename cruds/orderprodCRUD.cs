using cat.itb.M6NF2Prac.models;
using M6UF2Prac;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.cruds
{
    public class orderprodCRUD
    {
        public static ISet<orderprod> SelectAll()
        {
            ISet<orderprod> orderprods = new HashSet<orderprod>();
            using (var session = SessionFactoryStoreCloud.Open())
            {
                orderprods = new HashSet<orderprod>(session.Query<orderprod>()
                   .Fetch(x => x.product)
                   .Fetch(x => x.client)
                   .ToList());
            }
            return orderprods;
        }

        public static orderprod SelectById(int id)
        {
            orderprod orderprod = null;
            using (var session = SessionFactoryStoreCloud.Open())
            {
                orderprod = session.Get<orderprod>(id);
            }
            return orderprod;
        }

        public static void Insert(orderprod orderprod)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(orderprod);
                    transaction.Commit();
                }
            }
        }

        public static void Update(orderprod orderprod)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(orderprod);
                    transaction.Commit();
                }
            }
        }

        public static void Delete(orderprod orderprod)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(orderprod);
                    transaction.Commit();
                }
            }
        }

        public static ISet<orderprod> SelectCostHigherThan(double cost, int amount)
        {
            using var session = SessionFactoryStoreCloud.Open();

            var orders = session.CreateQuery("FROM orderprod o JOIN FETCH o.product WHERE o.cost > :cost AND o.amount > :amount")
                .SetParameter("cost", cost)
                .SetParameter("amount", amount)
                .List<orderprod>();

            return new HashSet<orderprod>(orders);
        }
    }
}
