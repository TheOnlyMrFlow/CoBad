using AccesseurPoonaCSV;
using Cobad.Domaine;
using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Exceptions;
using Cobad.Domaine.Metier.Modificateurs;
using Cobad.Domaine.PortsSecondaires.AccesPoona;
using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cobad.CLI.Commandes
{
    [Verb("sync", HelpText = "Synchroniser la base Cobad avec la base Poona")]
    class SynchroniserParCSV
    {

        private AccesseurPoonaParFichierCSV accesseurPoona;
        private IGestionaireClubs gestionaireClubs;
        private IGestionaireJoueurs gestionaireJoueurs;

        [Option('c', "clubs", HelpText = "Insere ou met a jour les clubs depuis un fichier CSV. Seuls les champs Poona sont affectes")]
        public string FichierClubs { get; set; }

        [Option('j', "joueurs", HelpText = "Insere ou met a jour les joueurs depuis un fichier CSV. Seuls les champs Poona sont affectes")]
        public string FichierJoueurs { get; set; }

        public int Run(AccesseurPoonaParFichierCSV accesseurPoona, IGestionaireClubs gestionaireClubs, IGestionaireJoueurs gestionaireJoueurs)
        {
            this.accesseurPoona = accesseurPoona;
            this.gestionaireClubs = gestionaireClubs;
            this.gestionaireJoueurs = gestionaireJoueurs;

            if (FichierClubs != null)
            {
                if (!File.Exists(FichierClubs))
                {
                    Console.WriteLine("Ce fichier n'existe pas");
                    return -1;
                }

                SynchroniserLesClubs();
            }

            if (FichierJoueurs != null)
            {
                if (!File.Exists(FichierJoueurs))
                {
                    Console.WriteLine("Ce fichier n'existe pas");
                    return -1;
                }

                SynchroniserLesJoueurs();
            }

            return -1;
        }


        private void SynchroniserLesClubs()
        {

            accesseurPoona.FixerLeFichierDesClubs(FichierClubs);
            var clubsPoona = accesseurPoona.ObtenirTousLesClubsDeLaBasePoona();

            foreach (var club in clubsPoona)
            {
                try
                {
                    ModifierClub(club);
                    Console.WriteLine("Mise a jour du club " + PrettyStringClub(club));
                }
                catch (ElementNonExistantException e)
                {
                    AjouterClub(club);
                    Console.WriteLine("Ajout du club " + PrettyStringClub(club));
                }
            }

        }

        private void SynchroniserLesJoueurs()
        {

            accesseurPoona.FixerLeFichierDesJoueurs(FichierJoueurs);
            var joueursPoona = accesseurPoona.ObtenirTousLesJoueursDeLaBasePoona();

            foreach (var joueur in joueursPoona)
            {
                try
                {
                    ModifierJoueur(joueur);
                    Console.WriteLine("Mise a jour du joueur " + PrettyStringJoueur(joueur));
                }
                catch (ElementNonExistantException e)
                {
                    AjouterJoueur(joueur);
                    Console.WriteLine("Ajout du joueur " + PrettyStringJoueur(joueur));
                }
            }
        }

        

        private void ModifierClub(Club club)
        {
            var modificateurClub = gestionaireClubs.ObtenirModificateurDeClub(club.Numero);
            modificateurClub
                .ModifierLesChampsPoona(club.champsPropresAPoona)
                .Sauvegarder();

        }

        private void AjouterClub(Club club)
        {
            var createurClub = gestionaireClubs.ObtenirCreateurDeClub();
            createurClub
                .DontLeNumeroEst(club.Numero)
                .DontLesChampsPoonaSont(club.champsPropresAPoona)
                .Creer();

        }

        private void ModifierJoueur(Joueur joueur)
        {
            var modificateurJoueurs = gestionaireJoueurs.ObtenirModificateurDeJoueur(joueur.Licence);
            modificateurJoueurs
                .ModifierLesChampsPoona(joueur.ChampsPropresAPoona)
                .Sauvegarder();

        }

        private void AjouterJoueur(Joueur joueur)
        {
            var createurJoueur = gestionaireJoueurs.ObtenirCreateurDeJoueur();
            createurJoueur
                .DontLeClubPorteLeNumero(joueur.NumeroClub)
                .DontLaLicenceEst(joueur.Licence)
                .DontLesChampsPoonaSont(joueur.ChampsPropresAPoona)
                .Creer();

        }
        private string PrettyStringClub(Club club)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(club.champsPropresAPoona.Nom);
            sb.Append(" (");
            sb.Append(club.Numero);
            sb.Append(")");
            return sb.ToString();
        }

        private string PrettyStringJoueur(Joueur joueur)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(joueur.ChampsPropresAPoona.Nom);
            sb.Append(" ");
            sb.Append(joueur.ChampsPropresAPoona.Prenom);
            sb.Append(" (");
            sb.Append(joueur.Licence);
            sb.Append(")");
            return sb.ToString();
        }



    }
}
