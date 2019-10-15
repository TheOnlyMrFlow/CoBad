using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.PortsSecondaires.Persistence
{
    public interface IRepertoireJoueurs
    {
        bool Existe(int license);
        Joueur ObtenirJoueurParLicense(int license);
        IEnumerable<Joueur> ObtenirTousLesJoueurs();
        void Ajouter(Joueur joueur);
        void MettreAJour(Joueur joueur);
        void MettreAJourOuAjouterSiExistePas(Joueur joueur);
    }
}
