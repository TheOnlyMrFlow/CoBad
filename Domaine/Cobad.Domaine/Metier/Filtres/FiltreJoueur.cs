using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Filtres
{
    public class FiltreJoueur : IFiltreJoueur
    {

        internal FiltreJoueur() { }

        public FiltreClub FiltrerParNom(string nom)
        {
            throw new NotImplementedException();
        }

        public FiltreClub FiltrerParLicense(string sigle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Club> OrdonnerParNom()
        {
            throw new NotImplementedException();
        }

    }
}
