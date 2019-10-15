using Cobad.Domaine;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cobad.StockageMySQL.DBSchema
{
    [Table(Name = "club_personnel")]
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
        internal Personnel ToPersonnel()
        {
            return new Personnel(
                stringToRole[Role],
                Nom,
                Tel,
                Mobile,
                Mail);
        }

        [Column(Name = "Role")]
        public string Role { get; set; }

        [Column(Name = "Numero-Club")]
        public string NumeroClub { get; set; }

        [Column(Name = "Nom")]
        public string Nom { get; set; }

        [Column(Name = "Tel")]
        public string Tel { get; set; }

        [Column(Name = "Mobile")]
        public string Mobile { get; set; }

        [Column(Name = "Mail")]
        public string Mail { get; set; }
    }
}
