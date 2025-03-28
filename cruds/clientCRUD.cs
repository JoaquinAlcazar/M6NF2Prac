using cat.itb.M6NF2Prac.models;
using FluentNHibernate.Conventions;
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

        public static void InsertADO(List<client> clients)
        {
            foreach (var item in clients)
            {
                storeConnection db = new storeConnection();

                var conn = db.GetConnection();

                using var cmd = new NpgsqlCommand();
                cmd.Connection = conn;

                string query = "INSERT INTO client (code, name) VALUES (" + item.code + ", '"+ item.name+"')";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                Console.WriteLine($"Registro con id: {item.code} insertado correctamente");

                // Close connection
                conn.Close();
            }
        }

        //Select and return the client
        public static client SelectByNameADO(string name)
        {

            storeConnection db = new storeConnection();

            var conn = db.GetConnection();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            string query = "SELECT * FROM client WHERE name = '" + name + "'";
            cmd.CommandText = query;

            NpgsqlDataReader dr = cmd.ExecuteReader();

            client client = new client();

            while (dr.Read())
            {
                client.id = dr.GetInt32(0);
                client.code = dr.GetInt32(1);
                client.name = dr.GetString(2);
            }

            // Close connection
            conn.Close();

            return client;

        }

        public static void DeleteADO(client client)
        {
            storeConnection db = new storeConnection();

            var conn = db.GetConnection();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            string query = "DELETE FROM client WHERE code = " + client.code;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            Console.WriteLine($"Registro con id: {client.code} eliminado correctamente");

            // Close connection
            conn.Close();
        }
    }
}
