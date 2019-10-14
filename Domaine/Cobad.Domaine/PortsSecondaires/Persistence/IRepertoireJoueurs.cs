using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.PortsSecondaires.Persistence
{
    public interface IRepertoireJoueurs
    {
        Joueur ObtenirJoueurParLicense(string nom);
        IEnumerable<Joueur> ObtenirTousLesJoueurs();
        void Ajouter(Joueur joueur);
        void MettreAJour(Joueur joueur);
        void MettreAJourOuAjouterSiExistePas(Joueur joueur);
    }
}
