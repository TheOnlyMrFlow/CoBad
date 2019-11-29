using Cobad.Domaine.PortsSecondaires;
using Cobad.Domaine.Metier;
using CommandLine;
using System;
using System.IO;
using ImportCompetitionXML;

namespace Cobad.CLI.Commandes
{
    [Verb("impcomp", HelpText = "Importer une competition par fichier XML")]
    class ImporterCompetition
    {

        private IImporteurDeCompetition importeurCompetition;
        private IGestionaireClubs gestionaireClubs;
        private IGestionaireJoueurs gestionaireJoueurs;

        [Option('f', "fichier", HelpText = "Importe une competition depuis le ficheir XML spécifié")]
        public string FichierCompetitions { get; set; }

        

        public int Run(IImporteurDeCompetition importeurCompetition)
        {
            this.importeurCompetition = importeurCompetition;

            if (FichierCompetitions != null)
            {
                if (!File.Exists(FichierCompetitions))
                {
                    Console.WriteLine("Ce fichier n'existe pas");
                    return -1;
                }

                ImporterLaCompetition();
                return 1;
            }

            return -1;
        }


        private void ImporterLaCompetition()
        {
            try
            {
                var competition = importeurCompetition.ExtraireCompetitionDe(FichierCompetitions, sauvegarder: true);
                Console.WriteLine("Competition {0} ajoutée", competition.Nom);
            }
            catch (DuplicationException e)
            {
                Console.WriteLine("Cette competition existe deja");
            }

        }

       


    }
}
