using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL.Adapters
{
    public class RepertoireClubs : IRepertoireClubs
    {
        public void Ajouter(Club club)
        {
            throw new NotImplementedException();
        }

        public void MettreAJour(Club club)
        {
            throw new NotImplementedException();
        }

        public void MettreAJourOuAjouterSiExistePas(Club club)
        {
            throw new NotImplementedException();
        }

        public Club ObtenirClubParNumero(string numero)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Club> ObtenirTousLesClubs()
        {
            throw new NotImplementedException();
        }
    }
}
