using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.PortsSecondaires.Persistence
{
    public interface IRepertoireCompetitions
    {
        bool Existe(string nomCompetition);

        void Ajouter(Competition competition);

    }
}
