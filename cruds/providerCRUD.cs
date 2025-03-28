using cat.itb.M6NF2Prac.models;
using M6UF2EA3.connections;
using M6UF2Prac;
using Npgsql;
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
                    Console.WriteLine($"Provider {provider.id} updated");
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

        public static ISet<provider> SelectCreditLowerThanADO(double credit)
        {
            storeConnection db = new storeConnection();

            var conn = db.GetConnection();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM provider WHERE credit < " + credit + "";
            cmd.ExecuteNonQuery();

            using var reader = cmd.ExecuteReader();
            ISet<provider> providers = new HashSet<provider>();
            while (reader.Read())
            {
                provider provider = new provider();
                provider.id = reader.GetInt32(0);
                provider.name = reader.GetString(1);
                provider.address = reader.GetString(2);
                provider.city = reader.GetString(3);
                provider.stcode = reader.GetString(4);
                provider.zipcode = reader.GetString(5);
                provider.area = reader.GetInt32(6);
                provider.phone = reader.GetString(7);
                provider.ammount = reader.GetInt32(8);
                provider.credit = (double)reader.GetDecimal(9);
                provider.remark = reader.IsDBNull(10) ? null : reader.GetDecimal(10).ToString();
                providers.Add(provider);
            }

            return providers;
        }


        public static provider SelectLowestAmount()
        {
            using var session = SessionFactoryStoreCloud.Open();

            var provider = session.QueryOver<provider>()
                .OrderBy(x => x.ammount).Asc
                .Take(1)
                .SingleOrDefault();

            return provider;
        }

        public static ISet<provider> SelectByCity(string city)
        {
            using var session = SessionFactoryStoreCloud.Open();

            var providers = session.CreateQuery("FROM provider p WHERE p.city = :city")
                .SetParameter("city", city)
                .List<provider>();

            return new HashSet<provider>(providers);

        }
    }
}
