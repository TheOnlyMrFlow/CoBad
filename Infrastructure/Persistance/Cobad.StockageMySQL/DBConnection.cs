using Cobad.StockageMySQL.DBSchema;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL
{
    class DBConnection : LinqToDB.Data.DataConnection
    {

        private static string ConnectionString = "";
        public DBConnection() : base("MySql", ConnectionString) { }

        public DBConnection(string connectionString) : base("MySql", connectionString) { }

        public static void SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public ITable<TableClub> Club => GetTable<TableClub>();

        public ITable<TableJoueur> Joueur => GetTable<TableJoueur>();

        public ITable<TableCollectif> Collectif => GetTable<TableCollectif>();

    }
}
