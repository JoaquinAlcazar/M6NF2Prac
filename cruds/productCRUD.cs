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

        public static product SelectByCodeADO(int code)
        {
            storeConnection db = new storeConnection();

            var conn = db.GetConnection();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM product WHERE code = @code";
            cmd.Parameters.AddWithValue("code", code);

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product producte = new product
                {
                    id = dr.GetInt32(0),
                    code = dr.GetInt32(1),
                    description = dr.GetString(2),
                    currentstock = dr.GetInt32(3),
                    minstock = dr.GetInt32(4),
                    price = dr.GetDouble(5),
                    salesp = salespersonCRUD.SelectById(dr.GetInt32(6))
                };

                return producte;
            }

            return null;
        }

        public static void UpdateADO(product product)
        {
            using (var session = SessionFactoryStoreCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    //update price
                    session.CreateSQLQuery("UPDATE product SET price = :price WHERE code = :code")
                        .SetParameter("price", product.price)
                        .SetParameter("code", product.code)
                        .ExecuteUpdate();
                }

                Console.WriteLine($"Product {product.code} updated");
            }
        }

        public static ISet<product> SelectByPriceHigherThan (double price)
        {
            using var session = SessionFactoryStoreCloud.Open();

            var products = session.QueryOver<product>()
                .Where(p => p.price > price)
                .SelectList(list => list
                    .Select(p => p.description)
                    .Select(p => p.price))
                .List<object[]>();

            ISet<product> productsSet = new HashSet<product>();

            foreach (object[] obj in products)
            {
                product product = new product
                {
                    description = obj[0].ToString(),
                    price = Convert.ToDouble(obj[1])
                };

                productsSet.Add(product);
            }

            return productsSet;

        }
    }
}
