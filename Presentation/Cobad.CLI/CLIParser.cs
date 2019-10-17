using System;
using AccesseurPoonaCSV;
using Cobad.CLI.Commandes;
using Cobad.Domaine;
using Cobad.Domaine.Metier;
using Cobad.Domaine.PortsSecondaires.AccesPoona;
using CommandLine;

namespace Cobad.CLI
{
    public class CLIParser
    {

        private IGestionaireClubs gestionaireClubs;
        private IGestionaireJoueurs gestionaireJoueurs;
        private IGestionaireCollectifs gestionaireCollectifs;
        private IAccesseurPoona accesseurPoona;

        public CLIParser(FrontiereCobad frontiereCobad)
        {
            this.gestionaireClubs = frontiereCobad.GestionaireClubs;
            this.gestionaireCollectifs = frontiereCobad.GestionaireCollectifs;
            this.gestionaireJoueurs = frontiereCobad.GestionaireJoueurs;
            this.accesseurPoona = frontiereCobad.AccesseurPoona;
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
                    SynchroniserParCSV>(args)
                .MapResult(
                    (CreerCollectif cmd) => cmd.Run(gestionaireCollectifs, gestionaireJoueurs),
                    (ModifierContactJoueur cmd) => cmd.Run(gestionaireJoueurs),
                    (AjouterPersonnel cmd) => cmd.Run(gestionaireClubs),
                    (ListerClubs cmd) => cmd.Run(gestionaireClubs.ObtenirFiltreDeClub()),
                    (ListerJoueurs cmd) => cmd.Run(gestionaireJoueurs.ObtenirFiltreDeJoueur()),
                    (SynchroniserParCSV cmd) => cmd.Run((AccesseurPoonaParFichierCSV) accesseurPoona, gestionaireClubs, gestionaireJoueurs),
                    errs => 1);
        }

        //public int ParseSynchroniser(string[] args)
        //{
        //    switch (accesseurPoona)
        //    {
        //        case AccesseurPoonaParFichierCSV accesseurCSV:
        //            return Parser
        //                    .Default
        //                    .ParseArguments<SynchroniserParCSV>(args)
        //                    .MapResult(
        //                        (SynchroniserParCSV cmd) => cmd.Run(accesseurCSV, gestionaireClubs, gestionaireJoueurs),
        //                        errs => 1
        //                    );

        //        default:
        //            return 1;

        //    }
        //}

    }
}
