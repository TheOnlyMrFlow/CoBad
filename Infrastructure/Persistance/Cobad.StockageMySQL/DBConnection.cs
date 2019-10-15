using Cobad.StockageMySQL.DBSchema;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL
{
    class DBConnection : LinqToDB.Data.DataConnection
    {

        private static string ConnectionStringSQL = "";
        public DBConnection() : base("MySql", ConnectionStringSQL) { }

        public DBConnection(string connectionString) : base("MySql", connectionString) { }

        public static void SetConnectionString(string connectionString)
        {
            ConnectionStringSQL = connectionString;
        }

        public ITable<TableClub> Club => GetTable<TableClub>();

        public ITable<TablePersonnel> Personnel => GetTable<TablePersonnel>();

        public ITable<TableJoueur> Joueur => GetTable<TableJoueur>();

        public ITable<TableCollectif> Collectif => GetTable<TableCollectif>();

    }
}
