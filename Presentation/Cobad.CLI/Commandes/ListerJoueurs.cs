using Cobad.CLI.Exceptions;
using Cobad.CLI.Helpers;
using Cobad.Domaine;
using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Filtres;
using CommandLine;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.CLI.Commandes
{
    [Verb("listerjoueurs", HelpText = "Liste tous les joueurs qui verifient les filtres passés en arguments")]
    class ListerJoueurs
    {

        [Option('C', HelpText = "Filtre par club (numero du club)")]
        public string FiltreNumeroClub { get; set; }

        [Option('A', HelpText = "Filtre par categorie d'age")]
        public string FiltreCategorie { get; set; }

        [Option('S', HelpText = "Filtre par sexe ('h' | 'f')")]
        public string FiltreSexe { get; set; }

        [Option("mailing", HelpText = "Filtre par sexe ('h' | 'f')")]
        public bool MailingList { get; set; }

        [Option('c', "club", HelpText = "Affiche le club du joueur")]
        public bool ShowClub { get; set; }

        [Option('a', "age", HelpText = "Affiche l'age du joueur")]
        public bool ShowAge { get; set; }

        [Option('s', "sexe", HelpText = "Affiche le sexe du joueur")]
        public bool ShowSexe { get; set; }

        [Option('v', "ville", HelpText = "Affiche la ville du joueur")]
        public bool ShowVille { get; set; }

        [Option('t', "tel", HelpText = "Affiche le telephone du joueur")]
        public bool ShowTel { get; set; }

        [Option('m', "mail", HelpText = "Affiche le mail du joueur")]
        public bool ShowMail { get; set; }

        private IFiltreJoueur filtreJoueur;



        public int Run(IFiltreJoueur filtreDeJoueur)
        {
            this.filtreJoueur = filtreDeJoueur;

            try
            {
                string mailingList;
                var joueurs = ObtenirJoueurs(out mailingList);
                AfficherJoueurs(joueurs);
                if (MailingList)
                {
                    Console.WriteLine("\nMailing List :");
                    Console.WriteLine(mailingList);
                }
                return 0;
            }
            catch(CLIExcepetion e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
        }

        public IEnumerable<Joueur> ObtenirJoueurs(out string mailingList)
        {

            if (FiltreNumeroClub != null)
                filtreJoueur.FiltrerParClub(FiltreNumeroClub);
            if (FiltreSexe != null)
                filtreJoueur.FiltrerparSexe(FiltreSexe[0]);
            if (FiltreCategorie != null)
                filtreJoueur.FiltrerParCategorie(Conversions.StringVersCategorie(FiltreCategorie));

            mailingList = filtreJoueur.GenererMailingList(" ; ");

            return filtreJoueur.OrdonnerParDefaut();
        }

        public void AfficherJoueurs(IEnumerable<Joueur> joueurs)
        {
            List<string> champsAffiches = new List<string> { "Nom", "Prenom" };
            if (this.ShowClub)
                champsAffiches.Add("Club");
            if (this.ShowAge)
                champsAffiches.Add("Age");
            if (this.ShowSexe)
                champsAffiches.Add("Sexe");
            if (this.ShowVille)
                champsAffiches.Add("Ville");
            if (this.ShowTel)
            {
                champsAffiches.Add("Tel (Poona)");
                champsAffiches.Add("Tel (CoBad)");
            }
            if (this.ShowMail)
            {
                champsAffiches.Add("Mail (Poona)");
                champsAffiches.Add("Mail (CoBad)");
            }


            var table = new ConsoleTable(champsAffiches.ToArray());
            champsAffiches.Clear();


            foreach (var j in joueurs)
            {
                champsAffiches.Add(j.ChampsPropresAPoona.Nom);
                champsAffiches.Add(j.ChampsPropresAPoona.Prenom);
                if (this.ShowClub)
                    champsAffiches.Add(j.NumeroClub);
                if (this.ShowAge)
                    champsAffiches.Add("" + j.ChampsPropresAPoona.AgeFinSaison);
                if (this.ShowSexe)
                    champsAffiches.Add("" + j.ChampsPropresAPoona.Sexe);
                if (this.ShowVille)
                    champsAffiches.Add(j.ChampsPropresAPoona.Ville);
                if (this.ShowTel)
                {
                    champsAffiches.Add(j.ChampsPropresAPoona.Tel);
                    champsAffiches.Add(j.Tel);
                }
                if (this.ShowMail)
                {
                    champsAffiches.Add(j.ChampsPropresAPoona.Mail);
                    champsAffiches.Add(j.Mail);
                }

                table.AddRow(champsAffiches.ToArray());
                champsAffiches.Clear();

            }

            Console.WriteLine(table);
        }

       
    }
}
