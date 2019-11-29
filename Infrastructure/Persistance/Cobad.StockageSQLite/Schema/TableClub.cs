using Cobad.Domaine;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.StockageSQLite.Schema
{
    [Table("Club")]
    internal class TableClub
    {
        public TableClub()
        {

        }

        public TableClub(Club club)
        {
            Numero = club.Numero;
            var champsPoona = club.champsPropresAPoona;
            Nom = champsPoona.Nom;
            Sigle = champsPoona.Sigle;
            Ville = champsPoona.Ville;
            CodePostal = champsPoona.CodePostal;
            AdressePointRemise = champsPoona.Adresse.PointRemise;
            AdresseLocalisation = champsPoona.Adresse.Localisation;
            AdresseAdresse = champsPoona.Adresse.NumeroEtRue;
            AdresseDistribution = champsPoona.Adresse.Distribution;
            AdresseCodePostal = champsPoona.Adresse.CodePostal;
            AdresseVille = champsPoona.Adresse.Ville;
            AdresseCedex = champsPoona.Adresse.Cedex;
            AdressePays = champsPoona.Adresse.Pays;
            NomPresident = champsPoona.NomPresident;
            IsCorpo = champsPoona.IsCorpo;
            Tel = champsPoona.Tel;
            Mobile = champsPoona.Mobile;
            Mail = champsPoona.Mail;
            SiteWeb = champsPoona.SiteWeb;
            foreach (var p in club.Personnel)
            {
                Personnel.Add(new TablePersonnel(club.Numero, p));
            }
        }

        public Club VersModeleClub()
        {
            var champsPoona = new Club.ChampsPoona(
                new Adresse(
                    this.AdressePays,
                    this.AdresseCodePostal,
                    this.AdresseCedex,
                    this.AdresseVille,
                    this.AdresseAdresse,
                    this.AdressePointRemise,
                    this.AdresseLocalisation,
                    this.AdresseDistribution
                    ),
                this.Nom,
                this.Sigle,
                this.Ville,
                this.CodePostal,
                this.NomPresident,
                this.IsCorpo,
                this.Tel,
                this.Mobile,
                this.Mail,
                this.SiteWeb
                );


            return new Club(
                this.Numero,
                champsPoona,
                this.Personnel.Select(
                    p => p.VersModelePersonnel()).ToList()
                );

        }


        [PrimaryKey, NotNull, Unique]
        public string Numero { get; set; }

        public string Nom { get; set; }

        public string Sigle { get; set; }

        public string Ville { get; set; }

        public string CodePostal { get; set; }

        [Column("Adresse-PointRemise")]
        public string AdressePointRemise { get; set; }

        [Column("Adresse-Localisation")]
        public string AdresseLocalisation { get; set; }

        [Column("Adresse-Adresse")]
        public string AdresseAdresse { get; set; }

        [Column("Adresse-Distribution")]
        public string AdresseDistribution { get; set; }

        [Column("Adresse-CodePostal")]
        public string AdresseCodePostal { get; set; }

        [Column("Adresse-Ville")]
        public string AdresseVille { get; set; }

        [Column("Adresse-Cedex")]
        public string AdresseCedex { get; set; }

        [Column("Adresse-Pays")]
        public string AdressePays { get; set; }

        public string NomPresident { get; set; }

        public bool IsCorpo { get; set; }

        public string Tel { get; set; }

        public string Mobile { get; set; }

        public string Mail { get; set; }

        public string SiteWeb { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TablePersonnel> Personnel { get; set; } = new List<TablePersonnel>();
    }
}



