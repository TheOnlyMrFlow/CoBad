using Cobad.Domaine;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.StockageSQLite.Schema
{
    [Table("Match")]
    class TableMatch
    {
        public TableMatch()
        {
        }

        public TableMatch(Match match)
        {
            this.Id = match.Id;

            this.joueurA1 = new TableJoueur(match.EquipeA[0]);
            this.joueurB1 = new TableJoueur(match.EquipeB[0]);

            if (match.EstUnMatchDouble)
            {
                this.joueurA1 = new TableJoueur(match.EquipeA[1]);
                this.joueurB1 = new TableJoueur(match.EquipeB[1]);
            }

            this.Sets = match.Sets.Select(s => new TableSet(s)).ToList();
            this.Abandon = match.Abandon;
            this.Forfait = match.Forfait;

        }

        public Match VersModeleMatch()
        {
            return new Match
            {
                Id = Id,
                Sets = Sets.Select(s => s.VersModeleSet()).ToArray(),
                Abandon = Abandon,
                Forfait = Forfait
            };
        }

        [PrimaryKey]
        public int Id { get; set; }

        [ForeignKey(typeof(TableJoueur))]
        public int licenseJoueurA1 { get; set; }

        [ManyToOne]
        public TableJoueur joueurA1 { get; set; }

        [ForeignKey(typeof(TableJoueur))]
        public int licenseJoueurA2 { get; set; }

        [ManyToOne]
        public TableJoueur joueurA2 { get; set; }

        [ForeignKey(typeof(TableJoueur))]
        public int licenseJoueurB1 { get; set; }

        [ManyToOne]
        public TableJoueur joueurB1 { get; set; }

        [ForeignKey(typeof(TableJoueur))]
        public int licenseJoueurAB2 { get; set; }

        [ManyToOne]
        public TableJoueur joueurB2 { get; set; }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TableSet> Sets { get; set; }

        public bool Abandon { get; set; }

        public bool Forfait { get; set; }

        [ForeignKey(typeof(TableRound))]
        public int RoundId { get; set; }


    }
}
