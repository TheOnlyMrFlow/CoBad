using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using LinqToDB;
using System.Linq;
using Cobad.StockageMySQL.DBSchema;

namespace Cobad.StockageMySQL.Adapters
{
    public class RepertoireJoueurs : IRepertoireJoueurs
    {
        public bool Existe(int license)
        {
            using (var db = new DBConnection())
            {
                var query =
                    from joueur in db.Joueur
                    where joueur.License == license
                    select joueur;

                return query.Count() != 0;

            }
        }

        public void Ajouter(Joueur joueur)
        {
            using (var db = new DBConnection())
            {
                db.Insert<TableJoueur>(new TableJoueur(joueur));
            }
        }

        public void MettreAJour(Joueur joueur)
        {
            using (var db = new DBConnection())
            {
                db.Update<TableJoueur>(new TableJoueur(joueur));
            }
        }

        public void MettreAJourOuAjouterSiExistePas(Joueur joueur)
        {
            throw new NotImplementedException();
        }

        public Joueur ObtenirJoueurParLicense(int license)
        {
            using (var db = new DBConnection())
            {
                var query =
                    from joueur in db.Joueur
                    where joueur.License == license
                    select SchemaJoueurVersJoueur(joueur);

                return query.First();

            }
        }

        public IEnumerable<Joueur> ObtenirTousLesJoueurs()
        {
            throw new NotImplementedException();
        }

        private Joueur SchemaJoueurVersJoueur(TableJoueur schemaJoueur)
        {
            var joueur =
                new Joueur(
                    schemaJoueur.License,
                    schemaJoueur.NumeroClub,
                    new Joueur.ChampsPoona(
                        schemaJoueur.Nom,
                        schemaJoueur.Prenom,
                        schemaJoueur.Age,
                        schemaJoueur.Sexe,
                        schemaJoueur.Ville,
                        schemaJoueur.Tel,
                        schemaJoueur.Mail,
                        StringVersCategorie(schemaJoueur.Categorie),
                        schemaJoueur.HebdoSimpleClassement,
                        schemaJoueur.HebdoSimpleCPPH,
                        schemaJoueur.HebdoDoubleClassement,
                        schemaJoueur.HebdoDoubleCPPH,
                        schemaJoueur.HebdoMixteClassement,
                        schemaJoueur.HebdoMixteCPPH,
                        schemaJoueur.CompetiteurActif,
                        schemaJoueur.Mute,
                        schemaJoueur.Unss,
                        schemaJoueur.Fnsu,
                        StringVersPlume(schemaJoueur.MeilleurPlume)
                        )
                    );

            joueur.Mail = schemaJoueur.CoBad_Mail;
            joueur.Tel = schemaJoueur.CoBad_Tel;

            return joueur;
        }

        private Categorie StringVersCategorie(string categorieAsString)
        {
            try
            {
                return Joueur.StringToCategorie[categorieAsString];
            }
            catch (ArgumentNullException e)
            {
                return Categorie.Aucune;
            }

        }

        private Plume StringVersPlume(string plumeAsString)
        {
            try
            {
                return Joueur.StringToPlume[plumeAsString];
            }
            catch (ArgumentNullException e)
            {
                return Plume.Aucune;
            }

        }
    }
}
