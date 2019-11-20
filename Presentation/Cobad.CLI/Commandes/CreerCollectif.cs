using Cobad.CLI.Exceptions;
using Cobad.CLI.Helpers;
using Cobad.Domaine;
using Cobad.Domaine.Metier;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cobad.CLI.Commandes
{
    [Verb("creercollectif", HelpText = "Crée un collectif")]
    class CreerCollectif
    {

        [Option('n', "nom", Required = true, HelpText = "Le nom (unique) du collectif")]
        public string Nom { get; set; }

        [Option('c', "categories", HelpText = "Les categories cibles du collectif")]
        public IEnumerable<string> Categories { get; set; }

        [Option('j', "categoriej", HelpText = "Les membres du collectif")]
        public IEnumerable<string> Membres { get; set; }

        public int Run(IGestionaireCollectifs gestionaireCollectifs, IGestionaireJoueurs gestionaireJoueurs)
        {
            var createurCollectif = gestionaireCollectifs.ObtenirCreateurDeCollectif();
            

            try
            {
                createurCollectif
                    .DontLeNomEst(Nom);

                if (Categories != null)
                {
                    createurCollectif
                        .DontLesCategoriesSont(Categories.Select(c => Conversions.StringVersCategorie(c)));
                }

                if (Membres != null)
                {
                    var joueurs = new List<Joueur>();
                    foreach(var m in Membres)
                    {
                        var filtreJoueur = gestionaireJoueurs.ObtenirFiltreDeJoueur();
                        var joueur = filtreJoueur.FiltrerParLicense(int.Parse(m)).OrdonnerParDefaut();
                        if (joueur.Count() == 0)
                            Console.WriteLine("La license " + m + " n'existe pas. Le joueur n'a pas été ajouteé");
                        else 
                            joueurs.Add(joueur.First());

                    }
                    createurCollectif
                        .DontLesMembresSont(joueurs);
                }

                createurCollectif.Creer();

                return 0;

            }
            catch(CLIExcepetion e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            catch(DuplicationException e)
            {
                Console.WriteLine("Un collectif porte deja ce nom");
                return 1;
            }
            catch (ElementNonExistantException e)
            {
                Console.WriteLine(e);
                return 1;
            }

        }
    }
}
