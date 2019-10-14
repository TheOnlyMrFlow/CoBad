using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Filtres
{
    public class FiltreCollectif : IFiltreCollectif
    {

        internal FiltreCollectif() { }

        public FiltreCollectif FiltrerParNom(string nom)
        {
            throw new NotImplementedException();
        }

        public FiltreCollectif FiltrerParCategorie(Categorie categorie)
        {
            throw new NotImplementedException();
        }

        public FiltreCollectif FiltrerParCategories(ICollection<Categorie> categories)
        {
            throw new NotImplementedException();
        }

        public FiltreCollectif FiltrerParMembre(int license)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Club> OrdonnerParNom()
        {
            throw new NotImplementedException();
        }

    }
}
