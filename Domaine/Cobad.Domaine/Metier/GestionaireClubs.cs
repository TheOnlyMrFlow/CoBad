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
    public class GestionaireClubs : IGestionaireClubs
    {

        private IRepertoireClubs repertoireClubs;

        internal GestionaireClubs(IRepertoireClubs repertoireClubs)
        {
            this.repertoireClubs =  repertoireClubs;
        }

        public ICreateurClub ObtenirCreateurDeClub()
        {
            return new CreateurClub(this.repertoireClubs);
        }

        public IFiltreClub ObtenirFiltreDeClub()
        {
            return new FiltreClub(this.repertoireClubs);
        }

        public IModificateurClub ObtenirModificateurDeClub(string numeroDuClubAModifier)
        {
            if (!repertoireClubs.Existe(numeroDuClubAModifier))
                throw new ElementNonExistantException();

            return new ModificateurClub(this.repertoireClubs, numeroDuClubAModifier);
        }
    }
}
