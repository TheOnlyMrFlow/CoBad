using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.PortsSecondaires.AccesPoona
{
    public interface IAccesseurPoona
    {
        IEnumerable<Club> ObtenirTousLesClubsDeLaBasePoona();

        IEnumerable<Joueur> ObtenirTousLesJoueursDeLaBasePoona();
    }
}
