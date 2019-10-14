using System.Collections.Generic;

namespace Cobad.Domaine.Metier.Filtres
{
    public interface IFiltreJoueur
    {
        FiltreClub FiltrerParLicense(string sigle);
        FiltreClub FiltrerParNom(string nom);
        IEnumerable<Club> OrdonnerParNom();
    }
}