using Cobad.CLI.Exceptions;
using Cobad.Domaine;
using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Exceptions;
using Cobad.Domaine.Metier.Modificateurs;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.CLI.Commandes
{
    [Verb("ajpersonnel", HelpText = "Ajouter un encadrant ou dirigeant a un club")]
    class AjouterPersonnel
    {

        [Option('c', "club", Required = true, HelpText = "Le numero du club dans lequel ajouter le dirigeant")]
        public string Numero { get; set; }

        [Option('r', "role", Required = true, HelpText = "Le role du dirigeant ('d' pour 'dirigeant', 'e' pour 'encadrant')")]
        public string Role { get; set; }

        [Option('n', "nom", Required = true, HelpText = "Le nom du dirigeant")]
        public string Nom { get; set; }

        [Option('t', "tel", HelpText = "Le telephone du dirigeant")]
        public string Tel { get; set; } = "";

        [Option('p', "portable", HelpText = "Le portable (mobile) du dirigeant")]
        public string Mobile { get; set; } = "";

        [Option('m', "mail", HelpText = "Le mail du dirigeant")]
        public string Mail { get; set; } = "";

        private IGestionaireClubs gestionaireClubs;

        public int Run(IGestionaireClubs gestionaireClubs)
        {
            this.gestionaireClubs = gestionaireClubs;

            try
            {
                var p = CreerPersonnel();
                return AjouterPersonnelAuClub(p);
            }
            catch (CLIExcepetion e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
        }

        public Personnel CreerPersonnel()
        {
            Personnel.Role role;

            if (Role.ToLower() == "d")
                role = Personnel.Role.Dirigeant;
            else if (Role.ToLower() == "e")
                role = Personnel.Role.Encadrant;
            else
                throw new ParametreIncorrecteException("Valeur incorrecte pour le role. Valeurs possibles : 'd' et 'e'");

            return new Personnel(role, Nom, Tel, Mobile, Mail);
        }

        public int AjouterPersonnelAuClub(Personnel personnel)
        {
            try
            {
                var modificateurClub = gestionaireClubs.ObtenirModificateurDeClub(Numero);
                modificateurClub.AjouterPersonnel(personnel).Sauvegarder();
                return 0;

            }
            catch(ElementNonExistantException e)
            {
                Console.WriteLine("Ce numero de club n'existe pas.");
                return 1;
            }   
        }
    }
}
