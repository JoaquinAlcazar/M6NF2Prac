using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace M6UF2EA3.connections
{
    public class storeConnection
    {
        //Class for ADO connections to database store
        private String HOST = "postgresql-joaquinalcazaritb.alwaysdata.net"; // Ubicació del servidor i el port de PotgreSQL.
        private String DB = "joaquinalcazaritb_store"; // Nom de la BD.
        private String USER = "joaquinalcazaritb";
        private String PASSWORD = "indescifrable1";

        // Specify connection options and open an connection
        public NpgsqlConnection conn = null;

        /**
         * Mètode per connectar a la base de dades store
         */
        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(
            "Host=" + HOST + ";" + "Username=" + USER + ";" +
            "Password=" + PASSWORD + ";" + "Database=" + DB + ";"
            );
            conn.Open();
            return conn;
        }
    }
}
