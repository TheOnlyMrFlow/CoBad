using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Cobad.StockageSQLite.Schema;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.StockageSQLite.Adapters
{
    public class RepertoireClub : IRepertoireClubs
    {
        private SQLiteConnection db;

        internal RepertoireClub(SQLiteConnection db)
        {
            this.db = db;
        }

        public void Ajouter(Club club)
        {
            db.InsertWithChildren(new TableClub(club), recursive: true);
        }

        public bool Existe(string numero)
        {
            return db.Find<TableClub>(numero) != null;

        }

        public void MettreAJour(Club club)
        {
            db.InsertOrReplaceWithChildren(new TableClub(club), recursive: true);
        }

        public void MettreAJourOuAjouterSiExistePas(Club club)
        {
            db.InsertOrReplaceWithChildren(new TableClub(club), recursive:true );
        }

        public Club ObtenirClubParNumero(string numero)
        {
            var club = db.FindWithChildren<TableClub>(numero, recursive: true);
            return club.VersModeleClub();
        }

        public IEnumerable<Club> ObtenirTousLesClubs()
        {
            return db
                .GetAllWithChildren<TableClub>(recursive: true)
                .Select(c => c.VersModeleClub());
        }

    }
}
