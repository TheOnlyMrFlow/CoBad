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
    internal class RepertoireJoueurs : IRepertoireJoueurs
    {
        private SQLiteConnection db;

        public RepertoireJoueurs(SQLiteConnection db)
        {
            this.db = db;
        }

        public void Ajouter(Joueur joueur)
        {
            db.InsertWithChildren(new TableJoueur(joueur), recursive: true);

        }

        public bool Existe(int license)
        {
            return db.Find<TableJoueur>(license) != null;
        }

        public void MettreAJour(Joueur joueur)
        {
            db.UpdateWithChildren(new TableJoueur(joueur));
        }

        public void MettreAJourOuAjouterSiExistePas(Joueur joueur)
        {
            db.InsertOrReplaceWithChildren(new TableJoueur(joueur), recursive: true);
        }

        public Joueur ObtenirJoueurParLicense(int license)
        {
            var joueur = db.FindWithChildren<TableJoueur>(license, recursive: true);
            return joueur.VersModeleJoueur();
        }

        public IEnumerable<Joueur> ObtenirTousLesJoueurs()
        {
            return db
                .GetAllWithChildren<TableJoueur>(recursive: true)
                .Select(j => j.VersModeleJoueur());
        }

        

    }
}