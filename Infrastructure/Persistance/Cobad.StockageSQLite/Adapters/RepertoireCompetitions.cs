using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Cobad.StockageSQLite.Schema;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageSQLite.Adapters
{
    class RepertoireCompetitions : IRepertoireCompetitions
    {
        private SQLiteConnection db;

        public RepertoireCompetitions(SQLiteConnection db)
        {
            this.db = db;
        }
        public bool Existe(string nomCompetition)
        {
            return db.Find<TableCompetition>(nomCompetition) != null;

        }

        public void Ajouter(Competition competition)
        {
            db.InsertWithChildren(new TableCompetition(competition), recursive: true);
        }

    }
}
