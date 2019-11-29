using Cobad.Domaine.PortsSecondaires.Persistence;
using Cobad.StockageSQLite.Schema;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageSQLite.Adapters
{
    public class FrontiereStockageSQLite : IFrontierePersistance
    {
        public SQLiteConnection connection;

        public FrontiereStockageSQLite(string dbFilePath = null)
        {
           if (dbFilePath == null)
            {
                var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var cobadFolder = System.IO.Path.Combine(appDataFolder, "Cobad");
                dbFilePath = System.IO.Path.Combine(cobadFolder, "cobad.db");

                if (!System.IO.File.Exists(dbFilePath))
                {
                    System.IO.Directory.CreateDirectory(cobadFolder);
                    System.IO.File.Create(dbFilePath).Close();
                }
            }


            connection = new SQLiteConnection(
                dbFilePath
                );
            connection.CreateTable<TableJoueur>();
            connection.CreateTable<TableCollectif>();
            connection.CreateTable<TableJonctionJoueurCollectif>();
            connection.CreateTable<TableClub>();
            connection.CreateTable<TablePersonnel>();

            connection.CreateTable<TableSet>();
            connection.CreateTable<TableMatch>();
            connection.CreateTable<TableRound>();
            connection.CreateTable<TableTableau>();
            connection.CreateTable<TableCompetition>();


            this.RepertoireClubs = new RepertoireClub(connection);
            this.RepertoireCollectifs = new RepertoireCollectifs(connection);
            this.RepertoireJoueurs = new RepertoireJoueurs(connection);
            this.RepertoireCompetitions = new RepertoireCompetitions(connection);

        }

        ~FrontiereStockageSQLite()
        {
            connection.Close();
        }

        public IRepertoireJoueurs RepertoireJoueurs { get; }

        public IRepertoireClubs RepertoireClubs { get; }

        public IRepertoireCollectifs RepertoireCollectifs { get; }

        public IRepertoireCompetitions RepertoireCompetitions { get; }
    }
}
