using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.PortsSecondaires.Persistence
{
    public interface IRepertoireClubs
    {

        bool Existe(string numero);

        Club ObtenirClubParNumero(string numero);

        IEnumerable<Club> ObtenirTousLesClubs();

        void Ajouter(Club club);

        void MettreAJour(Club club);

        void MettreAJourOuAjouterSiExistePas(Club club);

    }
}
