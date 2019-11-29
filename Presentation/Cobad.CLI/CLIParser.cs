using System;
using AccesseurPoonaCSV;
using Cobad.CLI.Commandes;
using Cobad.Domaine;
using Cobad.Domaine.Metier;
using Cobad.Domaine.PortsSecondaires.AccesPoona;
using Cobad.Domaine.PortsSecondaires;
using CommandLine;

namespace Cobad.CLI
{
    public class CLIParser
    {

        private IGestionaireClubs gestionaireClubs;
        private IGestionaireJoueurs gestionaireJoueurs;
        private IGestionaireCollectifs gestionaireCollectifs;
        private IAccesseurPoona accesseurPoona;
        private IImporteurDeCompetition importeurCompetition;

        public CLIParser(FrontiereCobad frontiereCobad)
        {
            this.gestionaireClubs = frontiereCobad.GestionaireClubs;
            this.gestionaireCollectifs = frontiereCobad.GestionaireCollectifs;
            this.gestionaireJoueurs = frontiereCobad.GestionaireJoueurs;
            this.accesseurPoona = frontiereCobad.AccesseurPoona;
            this.importeurCompetition = frontiereCobad.ImporteurCompetition;
        }

        public int Parse(string[] args)
        {            

            return
                Parser
                .Default
                .ParseArguments<
                    CreerCollectif,
                    ModifierContactJoueur,
                    AjouterPersonnel,
                    ListerClubs,
                    ListerJoueurs,
                    SynchroniserParCSV,
                    ImporterCompetition>(args)
                .MapResult(
                    (CreerCollectif cmd) => cmd.Run(gestionaireCollectifs, gestionaireJoueurs),
                    (ModifierContactJoueur cmd) => cmd.Run(gestionaireJoueurs),
                    (AjouterPersonnel cmd) => cmd.Run(gestionaireClubs),
                    (ListerClubs cmd) => cmd.Run(gestionaireClubs.ObtenirFiltreDeClub()),
                    (ListerJoueurs cmd) => cmd.Run(gestionaireJoueurs.ObtenirFiltreDeJoueur()),
                    (SynchroniserParCSV cmd) => cmd.Run((AccesseurPoonaParFichierCSV) accesseurPoona, gestionaireClubs, gestionaireJoueurs),
                    (ImporterCompetition cmd) => cmd.Run((importeurCompetition)),
                    errs => 1);
        }

    }
}
