using System;
using Cobad.CLI.Commandes;
using Cobad.Domaine;
using Cobad.Domaine.Metier;
using CommandLine;

namespace Cobad.CLI
{
    public class CLIParser
    {

        private IGestionaireClubs gestionaireClubs;
        private IGestionaireJoueurs gestionaireJoueurs;
        private IGestionaireCollectifs gestionaireCollectifs;

        public CLIParser(FrontiereCobad cobadBoundary)
        {
            this.gestionaireClubs = cobadBoundary.GestionaireClubs;
            this.gestionaireCollectifs = cobadBoundary.GestionaireCollectifs;
            this.gestionaireJoueurs = cobadBoundary.GestionaireJoueurs;
        }

        public int Parse(string[] args)
        {            

            return
                Parser.Default.
                ParseArguments<
                    AjouterCollectif,
                    AjouterContactJoueur,
                    AjouterPersonnel,
                    ListerClubs,
                    ListerJoueurs,
                    Synchroniser>(args)
                .MapResult(
                    (AjouterCollectif cmd) => cmd.Run(gestionaireCollectifs.ObtenirCreateurDeCollectif()),
                    (AjouterContactJoueur cmd) => cmd.Run(gestionaireJoueurs.ObtenirModificateurDeJoueur()),
                    (AjouterPersonnel cmd) => cmd.Run(gestionaireClubs.ObtenirModificateurDeClub()),
                    (ListerClubs cmd) => cmd.Run(gestionaireClubs.ObtenirFiltreDeClub()),
                    (ListerJoueurs cmd) => cmd.Run(gestionaireJoueurs.ObtenirFiltreDeJoueur()),
                    (Synchroniser cmd) => cmd.Run(gestionaireClubs.ObtenirModificateurDeClub(), gestionaireJoueurs.ObtenirModificateurDeJoueur()),
                    errs => 1);
        }

    }
}
