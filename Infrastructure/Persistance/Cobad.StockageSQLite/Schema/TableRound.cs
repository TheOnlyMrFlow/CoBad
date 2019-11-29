using Cobad.Domaine;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.StockageSQLite.Schema
{
    [Table("Round")]
    class TableRound
    {
        public TableRound()
        {
        }

        public TableRound(Round round)
        {
            this.Id = round.Id;

            this.Nom = round.Nom;

            this.Matchs = round.Matchs.Select(m => new TableMatch(m)).ToList();

        }

        public Round VersModeleRound()
        {
            return new Round
            {
                Id = Id,
                Nom = Nom,
                Matchs = Matchs.Select(m => m.VersModeleMatch())
               
            };
        }

        [PrimaryKey]
        public int Id { get; set; }

        public string Nom { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TableMatch> Matchs { get; set; }


        [ForeignKey(typeof(TableTableau))]
        public int TableauId { get; set; }

    }
}
