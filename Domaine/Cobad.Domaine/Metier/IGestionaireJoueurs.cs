using Cobad.Domaine.Metier.Createurs;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;

namespace Cobad.Domaine.Metier
{
    public interface IGestionaireJoueurs
    {
        ICreateurJoueur ObtenirCreateurDeJoueur();
        IFiltreJoueur ObtenirFiltreDeJoueur();
        IModificateurJoueur ObtenirModificateurDeJoueur(int license);
    }
}