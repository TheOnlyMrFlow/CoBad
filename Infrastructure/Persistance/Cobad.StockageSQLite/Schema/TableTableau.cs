using Cobad.Domaine;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.StockageSQLite.Schema
{
    [Table("Tableau")]
    class TableTableau
    {
        public TableTableau()
        {
        }

        public TableTableau(Tableau tableau)
        {
            this.Id = tableau.Id;

            this.Nom = tableau.Nom;

            this.Niveau = tableau.Niveau;

            this.Categorie = tableau.Categorie;

            this.Rounds = tableau.Rounds.Select(r => new TableRound(r)).ToList();


        }

        public Tableau VersModeleTableau()
        {
            return new Tableau
            {
                Id = Id,
                Nom = Nom,
                Niveau = Niveau,
                Rounds = Rounds.Select(r => r.VersModeleRound())

            };
        }

        [PrimaryKey]
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Niveau { get; set; }
        public string Categorie { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TableRound> Rounds { get; set; }

        [ForeignKey(typeof(TableCompetition))]
        public string CompetitionId { get; set; }


    }
}
