using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.PortsSecondaires.Persistence
{
    public interface IFrontierePersistance
    {
        IRepertoireClubs RepertoireClubs { get; }

        IRepertoireCollectifs RepertoireCollectifs { get; }

        IRepertoireJoueurs RepertoireJoueurs { get; }

        IRepertoireCompetitions RepertoireCompetitions { get; }
    }
}
