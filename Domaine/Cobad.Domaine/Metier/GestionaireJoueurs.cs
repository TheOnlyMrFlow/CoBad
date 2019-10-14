using Cobad.Domaine.Metier.Createurs;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier
{
    public class GestionaireJoueurs : IGestionaireJoueurs
    {
        IRepertoireJoueurs repertoireJoueurs;
        internal GestionaireJoueurs(IRepertoireJoueurs repertoireJoueurs)
        {
            this.repertoireJoueurs = repertoireJoueurs;
        }

        public ICreateurJoueur ObtenirCreateurDeJoueur()
        {
            throw new NotImplementedException();
        }

        public IFiltreJoueur ObtenirFiltreDeJoueur()
        {
            throw new NotImplementedException();
        }

        public IModificateurJoueur ObtenirModificateurDeJoueur()
        {
            throw new NotImplementedException();
        }
    }
}
