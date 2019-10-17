using System.Collections.Generic;

namespace Cobad.Domaine.Metier.Filtres
{
    public interface IFiltreClub
    {
        IFiltreClub FiltrerParNom(string nom);
        IFiltreClub FiltrerParSigle(string sigle);
        IEnumerable<Club> OrdonnerParNom();
        IEnumerable<Club> OrdonnerParNumero();
        IEnumerable<Club> OrdonnerParSigle();
        IEnumerable<Club> OrdonnerParDefaut();
    }
}