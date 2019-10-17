using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Cobad.StockageMySQL.DBSchema;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cobad.StockageMySQL.Adapters
{
    public class RepertoireCollectifs : IRepertoireCollectifs
    {
        public bool Existe(string nomCollectif)
        {
            using (var db = new DBConnection())
            {
                var query =
                    from col in db.Collectif
                    where col.Nom == nomCollectif
                    select col;

                return query.Count() != 0;

            }
        }

        public void Ajouter(Collectif collectif)
        {
            using (var db = new DBConnection())
            {
                db.BeginTransaction();

                db.Insert<TableCollectif>(new TableCollectif(collectif));

                foreach(var categorie in collectif.Categories)
                {
                    db.Insert<TableCibleCollectif>(new TableCibleCollectif(collectif.Nom, categorie));
                }
                foreach (var membre in collectif.Membres)
                {
                    db.Insert<TableMembreCollectif>(new TableMembreCollectif(collectif.Nom, membre.Licence));
                }

                db.CommitTransaction();
            }
        }

        public void MettreAJour(Collectif collectif)
        {
            throw new NotImplementedException();
        }

        public void MettreAJourOuAjouterSiExistePas(Collectif collectif)
        {
            throw new NotImplementedException();
        }

        public Collectif ObtenirCollectifParNom(string nom)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collectif> ObtenirTousLesCollectifs()
        {
            throw new NotImplementedException();
        }

        public void Supprimer(string nomCollectif)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(Collectif collectif)
        {
            throw new NotImplementedException();
        }
    }
}
