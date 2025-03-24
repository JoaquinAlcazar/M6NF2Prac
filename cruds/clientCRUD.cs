using cat.itb.M6NF2Prac.models;
using FluentNHibernate.Conventions;
using M6UF2Prac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.cruds
{
    public class clientCRUD
    {
        public static ISet<client> SelectAll()
        {
            ISet<client> clients = new HashSet<client>();
            using (var session = SessionFactoryStoreCloud.Open())
            {
                clients = new HashSet<client>(session.Query<client>().ToList());
            }
            return clients;
        }

        public static client SelectById(int id)
        {
            client client = null;
            using (var session = SessionFactoryStoreCloud.Open())
            {
                client = session.Get<client>(id);
            }
            return client;
        }

        public static void Insert(client client)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(client);
                    transaction.Commit();
                }
            }
        }

        public static void Update(client client)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(client);
                    transaction.Commit();
                }
            }
        }

        public static void Delete(client client)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(client);
                    transaction.Commit();
                }
            }
        }

    }
}
