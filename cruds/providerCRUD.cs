using cat.itb.M6NF2Prac.models;
using M6UF2Prac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.cruds
{
    public class providerCRUD
    {
        public static ISet<provider> SelectAll()
        {
            ISet<provider> providers = new HashSet<provider>();
            using (var session = SessionFactoryStoreCloud.Open())
            {
                providers = new HashSet<provider>(session.Query<provider>().ToList());
            }
            return providers;
        }

        public static provider SelectById(int id)
        {
            provider provider = null;
            using (var session = SessionFactoryStoreCloud.Open())
            {
                provider = session.Get<provider>(id);
            }
            return provider;
        }

        public static void Insert(provider provider)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(provider);
                    transaction.Commit();
                }
            }
        }

        public static void Update(provider provider)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(provider);
                    transaction.Commit();
                }
            }
        }

        public static void Delete(provider provider)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(provider);
                    transaction.Commit();
                }
            }
        }
    }
}
