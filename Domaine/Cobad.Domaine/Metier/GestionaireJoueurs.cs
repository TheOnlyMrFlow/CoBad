using Cobad.Domaine.Metier.Createurs;
using Cobad.Domaine.Metier.Exceptions;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier
{
    internal class GestionaireJoueurs : IGestionaireJoueurs
    {
        IRepertoireJoueurs repertoireJoueurs;
        IRepertoireClubs repertoireClubs;
        internal GestionaireJoueurs(IRepertoireJoueurs repertoireJoueurs, IRepertoireClubs repertoireClubs)
        {
            this.repertoireJoueurs = repertoireJoueurs;
            this.repertoireClubs = repertoireClubs;
        }

        public ICreateurJoueur ObtenirCreateurDeJoueur()
        {
            return new CreateurJoueur(repertoireJoueurs, repertoireClubs);
        }

        public IFiltreJoueur ObtenirFiltreDeJoueur()
        {
            return new FiltreJoueur(repertoireJoueurs);
        }

        public IModificateurJoueur ObtenirModificateurDeJoueur(int licenseDuJoueurAModifier)
        {
            if (! repertoireJoueurs.Existe(licenseDuJoueurAModifier))
                throw new ElementNonExistantException();

            return new ModificateurJoueur(this.repertoireJoueurs, licenseDuJoueurAModifier);
        }
    }
}
