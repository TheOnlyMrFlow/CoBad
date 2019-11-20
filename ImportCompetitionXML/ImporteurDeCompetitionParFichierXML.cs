using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;

namespace ImportCompetitionXML
{
    public class ImporteurDeCompetitionParFichierXML
    {
        IFrontierePersistance moyenDePersistance;
        public ImporteurDeCompetitionParFichierXML(IFrontierePersistance moyenDePersistance)
        {
            this.moyenDePersistance = moyenDePersistance;
        }

        //public void ImporterFichierXML(string cheminCompletDuFichier)
        //{
        //    var fichierXML = XDocument.Load(cheminCompletDuFichier);
        //    var competition = ExtraireCompetitionDe(fichierXML);

        //    repertoireCompetitions.Ajouter(competition);


        //}

        public Competition ExtraireCompetitionDe(XDocument fichier)
        {
            var elementXmlCompetition = fichier.Root;

            return new Competition {
                Nom = elementXmlCompetition.Element("TOURNAMENT").Attribute("NAME").Value,
                Date = StringVersDate(elementXmlCompetition.Element("TOURNAMENT").Attribute("DATE").Value),
                Tableaux = ExtraireTableauxDe(elementXmlCompetition)
            };

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
                select new Tableau {
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
                select new Round {
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
                select new Match {
                    Id = int.Parse(match.Attribute("IDMATCH").Value),
                    Abandon = pairs.Where(p => p.Attribute("WITHDRAWN").Value == "1").Any(),
                    Forfait = pairs.Where(p => p.Attribute("RETIRED").Value == "1").Any(),
                    ScoresA = ExtraireScoresDe(pairs.First()),
                    ScoresB = ExtraireScoresDe(pairs.Last()),
                    EquipeA = ExtraireEquipeDe(pairs.First()),
                    EquipeB = ExtraireEquipeDe(pairs.Last())
                };
        }


        private int[] ExtraireScoresDe(XElement pair)
        {
            var scoring = pair.Element("SCORING");

            var scores = new List<int>();


            var attributSet1 = scoring.Attribute("SET1");
            var valeurSet1 = int.Parse(attributSet1.Value);
            scores.Add(valeurSet1);

            var attributSet2 = scoring.Attribute("SET2");
            if (attributSet2 != null)
            {
                var valeurSet2 = int.Parse(attributSet2.Value);
                scores.Add(valeurSet2);
            }

            var attributSet3 = scoring.Attribute("SET3");
            if (attributSet3 != null)
            {
                var valeurSet3 = int.Parse(attributSet3.Value);
                scores.Add(valeurSet3);
            }

            return scores.ToArray();

        }

        private Joueur[] ExtraireEquipeDe(XElement pair)
        {
            var query =
                from joueur in pair.Elements("PLAYER")
                select
                    moyenDePersistance.
                    RepertoireJoueurs.
                    ObtenirJoueurParLicense(
                        int.Parse(
                            joueur.Attribute("IDPERS").Value
                            )
                        );

            return query.ToArray();
            
        }

    }
}
