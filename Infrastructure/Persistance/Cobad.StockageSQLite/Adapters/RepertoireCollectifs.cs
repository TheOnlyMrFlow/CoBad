using System;
using System.Collections.Generic;
using System.Linq;
using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Cobad.StockageSQLite.Schema;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace Cobad.StockageSQLite.Adapters
{
    internal class RepertoireCollectifs : IRepertoireCollectifs
    {
        private SQLiteConnection db;

        public RepertoireCollectifs(SQLiteConnection db)
        {
            this.db = db;
        }

        public void Ajouter(Collectif collectif)
        {
            db.InsertWithChildren(new TableCollectif(collectif), recursive: true);
        }

        public bool Existe(string nomCollectif)
        {
            return db.Find<TableCollectif>(nomCollectif) != null;

        }

        public void MettreAJour(Collectif collectif)
        {
            db.InsertOrReplaceWithChildren(new TableCollectif(collectif), recursive: true);
        }

        public void MettreAJourOuAjouterSiExistePas(Collectif collectif)
        {
            db.InsertOrReplaceWithChildren(new TableCollectif(collectif), recursive: true);
        }

        public Collectif ObtenirCollectifParNom(string nom)
        {
            var collectif = db.FindWithChildren<TableCollectif>(nom, recursive: true);
            return collectif.VersModeleCollectif();
        }


        public IEnumerable<Collectif> ObtenirTousLesCollectifs()
        {
            return db
                .GetAllWithChildren<TableCollectif>(recursive: true)
                .Select(c => c.VersModeleCollectif());
        }

        public void Supprimer(string nomCollectif)
        {
            db.Delete<TableCollectif>(nomCollectif);
        }

        public void Supprimer(Collectif collectif)
        {
            this.Supprimer(collectif.Nom);
        }

        
    }
}