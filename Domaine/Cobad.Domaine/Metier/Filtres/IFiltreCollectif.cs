using System.Collections.Generic;

namespace Cobad.Domaine.Metier.Filtres
{
    public interface IFiltreCollectif
    {
        FiltreCollectif FiltrerParCategorie(Categorie categorie);
        FiltreCollectif FiltrerParCategories(ICollection<Categorie> categories);
        FiltreCollectif FiltrerParMembre(int license);
        FiltreCollectif FiltrerParNom(string nom);
        IEnumerable<Club> OrdonnerParNom();
    }
}