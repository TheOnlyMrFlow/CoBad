using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Cobad.StockageMySQL.DBSchema;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LinqToDB;

namespace Cobad.StockageMySQL.Adapters
{
    public class RepertoireClubs : IRepertoireClubs
    {
        public bool Existe(string numero)
        {
            using (var db = new DBConnection())
            {
                var query =
                    from club in db.Club
                    where club.Numero == numero
                    select club;

                return query.Count() != 0;

            }
        }

        public void Ajouter(Club club)
        {
            using (var db = new DBConnection())
            {
                db.Insert<TableClub>(new TableClub(club));
                foreach(var personnel in club.Personnel)
                {
                    db.Insert<TablePersonnel>(new TablePersonnel(club.Numero, personnel));
                }
            }
        }

        public void MettreAJour(Club club)
        {
            using (var db = new DBConnection())
            {
                db.Update<TableClub>(new TableClub(club));
                foreach (var personnel in club.Personnel)
                {
                    db.InsertOrReplace<TablePersonnel>(new TablePersonnel(club.Numero, personnel));
                }
                var nomsPersonnelsAjoutes = club.Personnel.Select(p => p.Nom);
                var personnelsASupprimer =
                    (
                    from p in db.Personnel
                    where !nomsPersonnelsAjoutes.Contains(p.Nom)
                    select p
                    );

                foreach(var dbPersonnel in personnelsASupprimer)
                {
                    db.Delete<TablePersonnel>(dbPersonnel);
                }

            }

        }

        public void MettreAJourOuAjouterSiExistePas(Club club)
        {
            throw new NotImplementedException();
        }

        public Club ObtenirClubParNumero(string numero)
        {
            
            
            using (var db = new DBConnection())
            {
                var query =
                    from club in db.Club
                    where club.Numero == numero
                    select SchemaClubVersClub(club);

                return query.First();

            }
            
        }

        public IEnumerable<Club> ObtenirTousLesClubs()
        {
            throw new NotImplementedException();
        }


        internal Club SchemaClubVersClub(TableClub schemaClub)
        {

            var champsPoona = new Club.ChampsPoona(
                new Adresse(
                    schemaClub.AdressePays,
                    schemaClub.AdresseCodePostal,
                    schemaClub.AdresseCedex,
                    schemaClub.AdresseVille,
                    schemaClub.AdresseAdresse,
                    schemaClub.AdressePointRemise,
                    schemaClub.AdresseLocalisation,
                    schemaClub.AdresseDistribution
                    ),
                schemaClub.Nom,
                schemaClub.Sigle,
                schemaClub.Ville,
                schemaClub.CodePostal,
                schemaClub.NomPresident,
                schemaClub.IsCorpo,
                schemaClub.Tel,
                schemaClub.Mobile,
                schemaClub.Mail,
                schemaClub.SiteWeb
                );

            using (var db = new DBConnection())
            {
                var queryPersonnel =
                    from p in db.Personnel
                    where p.NumeroClub == schemaClub.Numero
                    select SchemaPersonnelVersPersonnel(p);

                return new Club(schemaClub.Numero, champsPoona, queryPersonnel.ToList());
            }

        }

        internal Personnel SchemaPersonnelVersPersonnel(TablePersonnel schemaPersonnel)
        {
            return new Personnel(
                TablePersonnel.stringToRole[schemaPersonnel.Role],
                schemaPersonnel.Nom,
                schemaPersonnel.Tel,
                schemaPersonnel.Mobile,
                schemaPersonnel.Mail);
        }
    }
}
