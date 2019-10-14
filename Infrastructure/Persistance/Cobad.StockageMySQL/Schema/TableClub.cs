using Cobad.Domaine;
using LinqToDB;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cobad.StockageMySQL.DBSchema
{
    [Table(Name = "club")]
    internal class TableClub
    {
        public TableClub() { }
        public TableClub(Club club)
        {
            Club.ChampsPoona champsPoona = club.champsPropresAPoona;
            Numero = champsPoona.Numero;
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
        }

        public Club ToClub()
        {
            Club.ChampsPoona champsPoona = new Club.ChampsPoona();
            Club.ChampsCobad champsCobad = new Club.ChampsCobad();

            champsPoona.Numero = Numero;
            champsPoona.Nom = Nom;
            champsPoona.Sigle = Sigle;
            champsPoona.Ville = Ville;
            champsPoona.CodePostal = CodePostal;
            Adresse adresse = new Adresse();
            adresse.PointRemise = AdressePointRemise;
            adresse.Localisation = AdresseLocalisation;
            adresse.NumeroEtRue = AdresseAdresse;
            adresse.Distribution = AdresseDistribution;
            adresse.CodePostal = AdresseCodePostal;
            adresse.Ville = AdresseVille;
            adresse.Cedex = AdresseCedex;
            adresse.Pays = AdressePays;           
            champsPoona.Adresse = adresse;
            champsPoona.NomPresident = NomPresident;
            champsPoona.IsCorpo = IsCorpo;
            champsPoona.Tel = Tel;
            champsPoona.Mobile = Mobile;
            champsPoona.Mail = Mail;
            champsPoona.SiteWeb = SiteWeb;
            champsCobad.Personnel = new List<Personnel>();

            foreach (var p in this.Personnel)
            {
                champsCobad.Personnel.Add(p.ToPersonnel());
            }

            Club club = new Club();
            club.champsPropresAPoona = champsPoona;
            club.champsPropresACobad = champsCobad;

            return club;
        }

        [Column(Name = "Numero"), PrimaryKey]
        public string Numero { get; set; }

        [Column(Name = "Nom")]
        public string Nom { get; set; }

        [Column(Name = "Sigle")]
        public string Sigle { get; set; }

        [Column(Name = "Ville")]
        public string Ville { get; set; }

        [Column(Name = "CodePostal")]
        public string CodePostal { get; set; }

        [Column(Name = "Adresse-PointRemise")]
        public string AdressePointRemise { get; set; }

        [Column(Name = "Adresse-Localisation")]
        public string AdresseLocalisation { get; set; }

        [Column(Name = "Adresse-Adresse")]
        public string AdresseAdresse { get; set; }

        [Column(Name = "Adresse-Distribution")]
        public string AdresseDistribution { get; set; }

        [Column(Name = "Adresse-CodePostal")]
        public string AdresseCodePostal { get; set; }

        [Column(Name = "Adresse-Ville")]
        public string AdresseVille { get; set; }

        [Column(Name = "Adresse-Cedex")]
        public string AdresseCedex { get; set; }

        [Column(Name = "Adresse-Pays")]
        public string AdressePays { get; set; }

        [Column(Name = "NomPresident")]
        public string NomPresident { get; set; }

        [Column(Name = "IsCorpo")]
        public bool IsCorpo { get; set; }

        [Column(Name = "Tel")]
        public string Tel { get; set; }

        [Column(Name = "Mobile")]
        public string Mobile { get; set; }

        [Column(Name = "Mail")]
        public string Mail { get; set; }

        [Column(Name = "SiteWeb")]
        public string SiteWeb { get; set; }

        [Association(QueryExpressionMethod = nameof(AssociationDirigeants))]
        public IEnumerable<TablePersonnel> Personnel { get; set; }

        public static Expression<Func<TableClub, IDataContext, IQueryable<TablePersonnel>>> AssociationDirigeants()
        {
            return (club, db) => db.GetTable<TablePersonnel>().Where(dirigeant => dirigeant.NumeroClub == club.Numero);
        }
    }
}
