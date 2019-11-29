using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageSQLite.Schema
{
    [Table("Jonction-Collectif-Joueur")]
    internal class TableJonctionJoueurCollectif
    {
        [ForeignKey(typeof(TableJoueur))]
        public int LicenseJoueur { get; set; }

        [ForeignKey(typeof(TableCollectif))]
        public string NomCollectif { get; set; }
    }
}
