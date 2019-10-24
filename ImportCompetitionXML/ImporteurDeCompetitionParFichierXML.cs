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
        //private IRepertoireCompetitions repertoireCompetitions;
        public ImporteurDeCompetitionParFichierXML(IRepertoireCompetitions repertoireCompetitions)
        {
           // this.repertoireCompetitions = repertoireCompetitions;
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
                Tableaux = ExtraireTableauxDe(elementXmlCompetition)
            };

        }

        private IEnumerable<Tableau> ExtraireTableauxDe(XElement competition)
        {
            return
                from tableau in competition.Elements("EVENT")
                select new Tableau { Nom = tableau.Attribute("NAME").Value };

        }

        //todo ici => extraireRoundsDe(tableau)

    }
}
