using Cobad.Domaine.Metier;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Createurs
{
    class CreateurClub : ICreateurClub
    {
        private string numero;
        private Club.ChampsPoona champsPoona = new Club.ChampsPoona();

        private IRepertoireClubs repertoireClubs;
        internal CreateurClub(IRepertoireClubs repertoireClubs)
        {
            this.repertoireClubs = repertoireClubs;
        }

        public ICreateurClub DontLeNumeroEst(string numero)
        {
            this.numero = numero;
            return this;
        }

        public ICreateurClub DontLesChampsPoonaSont(Club.ChampsPoona champsPoona)
        {
            this.champsPoona = champsPoona;
            return this;
        }

        public Club Creer()
        {
            if (numero == null)
                throw new ArgumentNullException("Il faut specifier au moins le numero du club");
            else if (repertoireClubs.Existe(numero))
                throw new DuplicationException();

            var club = new Club(numero, champsPoona);
            repertoireClubs.Ajouter(club);
            return club;
        }
    }
}
