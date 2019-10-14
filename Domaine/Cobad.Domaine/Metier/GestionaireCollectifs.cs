using Cobad.Domaine.Metier.Createurs;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier
{
    public class GestionaireCollectifs : IGestionaireCollectifs
    {
        IRepertoireCollectifs repertoireCollectifs;
        internal GestionaireCollectifs(IRepertoireCollectifs repertoireCollectifs)
        {
            this.repertoireCollectifs = repertoireCollectifs;
        }

        public ICreateurCollectif ObtenirCreateurDeCollectif()
        {
            throw new NotImplementedException();
        }

        public IFiltreCollectif ObtenirFiltreDeCollectif()
        {
            throw new NotImplementedException();
        }

        public IModificateurCollectif ObtenirModificateurDeCollectif()
        {
            throw new NotImplementedException();
        }
    }
}
