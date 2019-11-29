using Cobad.Domaine;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageSQLite.Schema
{
    [Table("Set")]
    class TableSet
    {
        public TableSet()
        {
        }

        public TableSet(Set set)
        {
            this.ScoreA = ScoreA;
            this.ScoreB = ScoreB;
        }

        public Set VersModeleSet()
        {
            return new Set
            {
                ScoreA = ScoreA,
                ScoreB = ScoreB
            };
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ScoreA { get; set; }

        public int ScoreB { get; set; }

        [ForeignKey(typeof(TableMatch))]
        public int MatchId { get; set; }


    }
}
