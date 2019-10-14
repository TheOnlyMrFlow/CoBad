using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Createurs
{
    public class CreateurClub : ICreateurClub
    {
        private IRepertoireClubs repertoireClubs;
        internal CreateurClub(IRepertoireClubs repertoireClubs)
        {
            this.repertoireClubs = repertoireClubs;
        }

        public CreateurClub DontLesChampsPoonaSont(Club.ChampsPoona champsPoona)
        {
            throw new NotImplementedException();
        }

        public Club Creer()
        {
            throw new NotImplementedException();
        }
    }
}
