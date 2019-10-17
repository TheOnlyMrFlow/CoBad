using Cobad.Domaine;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL.DBSchema
{
    [Table(Name = "collectif_cible")]
    internal class TableCibleCollectif
    {
        public TableCibleCollectif() { }

        public TableCibleCollectif(string nomCollectif, Categorie categorieCible)
        {
            this.NomCollectif = nomCollectif;
            this.CategorieCible = Joueur.CategorieToString[categorieCible];
        }

        [Column(Name = "NomCollectif")]
        public string NomCollectif { get; set; }

        [Column(Name = "CategorieCible")]
        public string CategorieCible { get; set; }
    }
}
