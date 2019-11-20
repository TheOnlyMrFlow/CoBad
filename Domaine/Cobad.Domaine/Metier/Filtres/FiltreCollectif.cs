using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Filtres
{
    class FiltreCollectif : IFiltreCollectif
    {

        internal FiltreCollectif() { }

        public IFiltreCollectif FiltrerParNom(string nom)
        {
            throw new NotImplementedException();
        }

        public IFiltreCollectif FiltrerParCategorie(Categorie categorie)
        {
            throw new NotImplementedException();
        }

        public IFiltreCollectif FiltrerParCategories(ICollection<Categorie> categories)
        {
            throw new NotImplementedException();
        }

        public IFiltreCollectif FiltrerParMembre(int license)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Club> OrdonnerParNom()
        {
            throw new NotImplementedException();
        }

    }
}
