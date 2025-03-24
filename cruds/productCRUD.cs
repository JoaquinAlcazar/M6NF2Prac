using cat.itb.M6NF2Prac.models;
using M6UF2Prac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.cruds
{
    public class productCRUD
    {
        public static ISet<product> SelectAll()
        {
            ISet<product> products = new HashSet<product>();
            using (var session = SessionFactoryStoreCloud.Open())
            {
                products = new HashSet<product>(session.Query<product>().ToList());
            }
            return products;
        }

        public static product SelectById(int id)
        {
            product product = null;
            using (var session = SessionFactoryStoreCloud.Open())
            {
                product = session.Get<product>(id);
            }
            return product;
        }

        public static void Insert(product product)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(product);
                    transaction.Commit();
                }
            }
        }

        public static void Update(product product)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(product);
                    transaction.Commit();
                }
            }
        }

        public static void Delete(product product)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(product);
                    transaction.Commit();
                }
            }
        }
    }
}
