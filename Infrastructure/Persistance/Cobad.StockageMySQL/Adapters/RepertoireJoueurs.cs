using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL.Adapters
{
    public class RepertoireJoueurs : IRepertoireJoueurs
    {
        public void Ajouter(Joueur joueur)
        {
            throw new NotImplementedException();
        }

        public void MettreAJour(Joueur joueur)
        {
            throw new NotImplementedException();
        }

        public void MettreAJourOuAjouterSiExistePas(Joueur joueur)
        {
            throw new NotImplementedException();
        }

        public Joueur ObtenirJoueurParLicense(string nom)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Joueur> ObtenirTousLesJoueurs()
        {
            throw new NotImplementedException();
        }
    }
}
