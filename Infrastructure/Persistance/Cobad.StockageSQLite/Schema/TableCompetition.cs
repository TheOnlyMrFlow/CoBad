using Cobad.Domaine;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.StockageSQLite.Schema
{
    [Table("Competition")]
    class TableCompetition
    {
        public TableCompetition()
        {
        }

        public TableCompetition(Competition competition)
        {

            this.Nom = competition.Nom;

            this.Date = DateVersString(competition.Date);

            this.Tableaux = competition.Tableaux.Select(t => new TableTableau(t)).ToList();
        }

        public Competition VersModeleCompetition()
        {
            return new Competition
            {
                Nom = Nom,
                Date = StringVersDate(Date),
                Tableaux= Tableaux.Select(t => t.VersModeleTableau())

            };
        }

        private DateTime StringVersDate(string date)
        {
            var dateDecoupee = date.Split('-');
            var annee = int.Parse(dateDecoupee[0]);
            var mois = int.Parse(dateDecoupee[1]);
            var jour = int.Parse(dateDecoupee[2]);

            return new DateTime(annee, mois, jour);

        }

        public string DateVersString(DateTime date)
        {

            return String.Join("-", date.Day, date.Month, date.Year);

        }

        [PrimaryKey]
        public string Nom { get; set; }

        public string Date { get; set; }        

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TableTableau> Tableaux { get; set; }




    }
}
