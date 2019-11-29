using Cobad.Domaine;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.StockageSQLite.Schema
{
    [Table("Club_Personnel")]
    internal class TablePersonnel
    {
        public static readonly Dictionary<Personnel.Role, string> roleToString = new Dictionary<Personnel.Role, string>
        {
            {Personnel.Role.Encadrant, "Encadrant" },
            {Personnel.Role.Dirigeant, "Dirigeant" }
        };

        public static readonly Dictionary<string, Personnel.Role> stringToRole = roleToString.ToDictionary(i => i.Value, i => i.Key);

        public TablePersonnel() { }

        public TablePersonnel(string numeroClub, Personnel personnel)
        {
            NumeroClub = numeroClub;
            Role = roleToString[personnel.RoleInClub];
            Nom = personnel.Nom;
            Tel = personnel.Tel;
            Mobile = personnel.Mobile;
            Mail = personnel.Mail;
        }

        public Personnel VersModelePersonnel()
        {
            return new Personnel(
                TablePersonnel.stringToRole[this.Role],
                this.Nom,
                this.Tel,
                this.Mobile,
                this.Mail);
        }

        [Column("Role")]
        public string Role { get; set; }

        [Column("Numero-Club"), ForeignKey(typeof(TableClub))]
        public string NumeroClub { get; set; }

        [Column("Nom"), PrimaryKey, NotNull, Unique]
        public string Nom { get; set; }

        [Column("Tel")]
        public string Tel { get; set; }

        [Column("Mobile")]
        public string Mobile { get; set; }

        [Column("Mail")]
        public string Mail { get; set; }

    }
}
