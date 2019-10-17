using System.Collections.Generic;

namespace Cobad.Domaine.Metier.Filtres
{
    public interface IFiltreCollectif
    {
        IFiltreCollectif FiltrerParCategorie(Categorie categorie);
        IFiltreCollectif FiltrerParCategories(ICollection<Categorie> categories);
        IFiltreCollectif FiltrerParMembre(int license);
        IFiltreCollectif FiltrerParNom(string nom);
        IEnumerable<Club> OrdonnerParNom();
    }
}