using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Modificateurs;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.CLI.Commandes
{

    [Verb("modifcoordjoueur", HelpText = "Midifie les coordonnees d'un joueur")]
    class ModifierContactJoueur
    {

        [Option('j', "joueur", Required = true, HelpText = "La license du joueur pour lequel ajouter les coordonnees")]
        public int License { get; set; }

        [Option('t', "tel", HelpText = "Le telephone du joueur")]
        public string Tel { get; set; }

        [Option('m', "mail", HelpText = "Le mail du joueur")]
        public string Mail { get; set; }


        public int Run(IGestionaireJoueurs gestionaireJoueurs)
        {
            try
            {
                var modificateurJoueur = gestionaireJoueurs.ObtenirModificateurDeJoueur(License);

                if (Tel != null)
                    modificateurJoueur.ModifierTelephone(Tel);
                if (Mail != null)
                    modificateurJoueur.ModifierMail(Mail);

                modificateurJoueur.Sauvegarder();

                return 0;
            }
            catch (ElementNonExistantException e)
            {
                Console.WriteLine("Aucun joueur ne porte cette license.");
                return 1;
            }
        }
    }
}
