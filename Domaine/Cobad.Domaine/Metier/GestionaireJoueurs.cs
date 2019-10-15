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
    public class GestionaireJoueurs : IGestionaireJoueurs
    {
        IRepertoireJoueurs repertoireJoueurs;
        internal GestionaireJoueurs(IRepertoireJoueurs repertoireJoueurs)
        {
            this.repertoireJoueurs = repertoireJoueurs;
        }

        public ICreateurJoueur ObtenirCreateurDeJoueur()
        {
            return new CreateurJoueur(repertoireJoueurs);
        }

        public IFiltreJoueur ObtenirFiltreDeJoueur()
        {
            return new FiltreJoueur(repertoireJoueurs);
        }

        public IModificateurJoueur ObtenirModificateurDeJoueur(int licenseDuJoueurAModifier)
        {
            if (!repertoireJoueurs.Existe(licenseDuJoueurAModifier))
                throw new ElementNonExistantException();

            return new ModificateurJoueur(this.repertoireJoueurs, licenseDuJoueurAModifier);
        }
    }
}
