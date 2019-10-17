using Cobad.Domaine;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL.DBSchema
{
    [Table(Name = "collectif")]
    internal class TableCollectif
    {
        public TableCollectif() { }

        public TableCollectif(Collectif collectif)
        {
            this.Nom = collectif.Nom;
        }

        public TableCollectif(string nom)
        {
            this.Nom = nom;
        }

        [Column(Name = "Nom")]
        public string Nom { get; set; }
    }
}
