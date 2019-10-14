using Cobad.Domaine.Metier.Createurs;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;

namespace Cobad.Domaine.Metier
{
    public interface IGestionaireCollectifs
    {
        ICreateurCollectif ObtenirCreateurDeCollectif();
        IFiltreCollectif ObtenirFiltreDeCollectif();
        IModificateurCollectif ObtenirModificateurDeCollectif();
    }
}