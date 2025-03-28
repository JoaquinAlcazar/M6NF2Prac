using System;
using M6UF2Prac;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cat.itb.M6NF2Prac.models;
using M6UF2EA3.connections;
using Npgsql;
using NHibernate.Stat;
using NHibernate;

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

        public static void InsertADO(List<salesperson> salespersons)
        {
            storeConnection db = new storeConnection();

            var conn = db.GetConnection();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            foreach (salesperson salesperson in salespersons)
            {
                cmd.CommandText = "INSERT INTO salesperson (surname, job, startdate, salary, commission, dep) VALUES (@surname, @job, @startdate, @salary, @commission, @dep)";
                cmd.Parameters.AddWithValue("surname", salesperson.surname);
                cmd.Parameters.AddWithValue("job", salesperson.job);
                cmd.Parameters.AddWithValue("startdate", salesperson.startdate);
                cmd.Parameters.AddWithValue("salary", salesperson.salary);
                cmd.Parameters.AddWithValue("commission", salesperson.commission);
                cmd.Parameters.AddWithValue("dep", salesperson.dep);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                Console.WriteLine($"Salesperson {salesperson.surname} insertada correctamente");
            }
        }

        public static salesperson SelectBySurname(string surname)
        {
            using var session = SessionFactoryStoreCloud.Open();

            var salesperson = session.CreateQuery("FROM salesperson WHERE surname = :surname")
                .SetParameter("surname", surname)
                .UniqueResult<salesperson>();

            if (salesperson != null)
            {
                NHibernateUtil.Initialize(salesperson.Products); // 🔹 Se asegura de cargar la colección
            }

            return salesperson;
        }

    }    
}
