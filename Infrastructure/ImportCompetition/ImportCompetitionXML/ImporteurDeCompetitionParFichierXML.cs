using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires;
using Cobad.Domaine.Metier;
using Cobad.Domaine.PortsSecondaires.Persistence;

namespace ImportCompetitionXML
{

    public class ImporteurDeCompetitionParFichierXML : IImporteurDeCompetition
    {
        IFrontierePersistance moyenDePersistance;
        public ImporteurDeCompetitionParFichierXML(IFrontierePersistance moyenDePersistance)
        {
            this.moyenDePersistance = moyenDePersistance;
        }


        public Competition ExtraireCompetitionDe(string cheminDuFichier, bool sauvegarder = false)
        {
            return ExtraireCompetitionDe(XDocument.Load(cheminDuFichier), sauvegarder);
        }

        public Competition ExtraireCompetitionDe(XDocument fichier, bool sauvegarder = false)
        {
            var elementXmlCompetition = fichier.Root;

            var competition = new Competition
            {
                Nom = elementXmlCompetition.Element("TOURNAMENT").Attribute("NAME").Value,
                Date = StringVersDate(elementXmlCompetition.Element("TOURNAMENT").Attribute("DATE").Value),
                Tableaux = ExtraireTableauxDe(elementXmlCompetition)
            };

            if (sauvegarder)
            {
                if (moyenDePersistance.RepertoireCompetitions.Existe(competition.Nom))
                {
                    throw new DuplicationException();
                }
                moyenDePersistance.RepertoireCompetitions.Ajouter(competition);
            }

            return competition;

        }


        public DateTime StringVersDate(string date)
        {
            var dateDecoupee = date.Split('-');
            var annee = int.Parse(dateDecoupee[0]);
            var mois = int.Parse(dateDecoupee[1]);
            var jour = int.Parse(dateDecoupee[2]);

            return new DateTime(annee, mois, jour);

        }

        private IEnumerable<Tableau> ExtraireTableauxDe(XElement competition)
        {
            return
                from tableau in competition.Elements("EVENT")
                select new Tableau
                {
                    Nom = tableau.Attribute("NAME").Value,
                    Id = int.Parse(tableau.Attribute("IDEVENT").Value),
                    Categorie = tableau.Attribute("CATEGORY").Value,
                    Niveau = tableau.Attribute("LEVEL").Value,
                    Rounds = ExtraireRoundsDe(tableau)
                };

        }

        private IEnumerable<Round> ExtraireRoundsDe(XElement tableau)
        {
            return
                from round in tableau.Elements("ROUND")
                select new Round
                {
                    Nom = round.Attribute("NAME").Value,
                    Matchs = ExtraireMatchsDe(round),
                    Id = int.Parse(round.Attribute("IDROUND").Value),

                };

        }

        private IEnumerable<Match> ExtraireMatchsDe(XElement round)
        {

            return
                from match in round.Elements("MATCH")
                let pairs = match.Elements("PAIR")
                select new Match
                {
                    Id = int.Parse(match.Attribute("IDMATCH").Value),
                    Abandon = pairs.Where(p => p.Attribute("WITHDRAWN").Value == "1").Any(),
                    Forfait = pairs.Where(p => p.Attribute("RETIRED").Value == "1").Any(),
                    Sets = ExtraireSetsDe(match),
                    EquipeA = ExtraireEquipeDe(pairs.First()),
                    EquipeB = ExtraireEquipeDe(pairs.Last())
                };
        }

        public Set[] ExtraireSetsDe(XElement match)
        {

            var pairs = match.Elements("PAIR");
            var scoringA = pairs.First().Element("SCORING");
            var scoringB = pairs.ElementAt(1).Element("SCORING");

            var sets = new List<Set>();

            sets.Add(
                new Set
                {
                    ScoreA = int.Parse(scoringA.Attribute("SET1").Value),
                    ScoreB = int.Parse(scoringB.Attribute("SET1").Value)
                }
            );

            if (scoringA.Attribute("SET2") != null)
            {

                sets.Add(
                    new Set
                    {
                        ScoreA = int.Parse(scoringA.Attribute("SET2").Value),
                        ScoreB = int.Parse(scoringB.Attribute("SET2").Value)
                    }
                );
            }

            if (scoringA.Attribute("SET3") != null)
            {

                sets.Add(
                    new Set
                    {
                        ScoreA = int.Parse(scoringA.Attribute("SET3").Value),
                        ScoreB = int.Parse(scoringB.Attribute("SET3").Value),
                    }
                );
            }

            return sets.ToArray();

        }


        private Joueur[] ExtraireEquipeDe(XElement pair)
        {

            var query =
                from joueur in pair.Elements("PLAYER")
                let licenseJoueurSupposee = int.Parse(joueur.Attribute("IDPERS").Value)
                let existe = moyenDePersistance.RepertoireJoueurs.Existe(licenseJoueurSupposee)
                let license = existe ? licenseJoueurSupposee : 0
                select
                    moyenDePersistance.
                        RepertoireJoueurs.
                        ObtenirJoueurParLicense(
                            license
                            );

            return query.ToArray();

        }

    }
}
