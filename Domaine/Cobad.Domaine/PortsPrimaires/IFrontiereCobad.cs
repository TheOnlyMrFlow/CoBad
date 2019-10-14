using Cobad.Domaine.Metier;

namespace Cobad.Domaine
{
    public interface IFrontiereCobad
    {
        IGestionaireClubs GestionaireClubs { get; }
        IGestionaireCollectifs GestionaireCollectifs { get; }
        IGestionaireJoueurs GestionaireJoueurs { get; }
    }
}