using System.Collections.Generic;

namespace Cobad.Domaine.Metier.Filtres
{
    public interface IFiltreClub
    {
        FiltreClub FiltrerParNom(string nom);
        FiltreClub FiltrerParSigle(string sigle);
        IEnumerable<Club> OrdonnerParNom();
        IEnumerable<Club> OrdonnerParNumero();
        IEnumerable<Club> OrdonnerParSigle();
        IEnumerable<Club> OrdonnerParDefaut();
    }
}