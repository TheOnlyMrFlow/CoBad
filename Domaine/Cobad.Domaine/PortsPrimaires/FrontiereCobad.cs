using Cobad.Domaine.Metier;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;

namespace Cobad.Domaine
{
    public class FrontiereCobad : IFrontiereCobad
    {
        public IGestionaireClubs GestionaireClubs { get; private set; }
        public IGestionaireCollectifs GestionaireCollectifs { get; private set; }
        public IGestionaireJoueurs GestionaireJoueurs { get; private set; }

        public FrontiereCobad(IFrontierePersistance frontierePersistance)
        {
            GestionaireClubs = new GestionaireClubs(frontierePersistance.RepertoireClubs);
            GestionaireCollectifs = new GestionaireCollectifs(frontierePersistance.RepertoireCollectifs);
            GestionaireJoueurs = new GestionaireJoueurs(frontierePersistance.RepertoireJoueurs);
        }
    }
}
