using System;
using M6UF2Prac;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cat.itb.M6NF2Prac.models;

namespace cat.itb.M6NF2Prac.cruds
{
    public class salespersonCRUD
    {
        public static ISet<salesperson> SelectAll()
        {
            ISet<salesperson> salespersons = new HashSet<salesperson>();
            using (var session = SessionFactoryStoreCloud.Open())
            {
                salespersons = new HashSet<salesperson>(session.Query<salesperson>().ToList());
            }
            return salespersons;
        }

        public static salesperson SelectById(int id)
        {
            salesperson salesperson = null;
            using (var session = SessionFactoryStoreCloud.Open())
            {
                salesperson = session.Get<salesperson>(id);
            }
            return salesperson;
        }

        public static void Insert(salesperson salesperson)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(salesperson);
                    transaction.Commit();
                }
            }
        }

        public static void Update(salesperson salesperson)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(salesperson);
                    transaction.Commit();
                }
            }
        }

        public static void Delete(salesperson salesperson)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(salesperson);
                    transaction.Commit();
                }
            }
        }
    }
}
