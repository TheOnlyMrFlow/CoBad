using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.PortsSecondaires
{
    public interface  IImporteurDeCompetition
    {
        Competition ExtraireCompetitionDe(string cheminDuFichier, bool sauvegarder = false);
    }
}
