using Cobad.Domaine;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL.DBSchema
{
    [Table(Name = "collectif_membre")]
    internal class TableMembreCollectif
    {
        public TableMembreCollectif() { }

        public TableMembreCollectif(string nomCollectif, int licenseJoueur)
        {
            this.NomCollectif = nomCollectif;
            this.LicenseJoueur = licenseJoueur;
        }

        [Column(Name = "NomCollectif")]
        public string NomCollectif { get; set; }

        [Column(Name = "LicenseJoueur")]
        public int LicenseJoueur { get; set; }
    }
}
