using Cobad.Domaine.Metier.Exceptions;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Createurs
{
    public class CreateurClub : ICreateurClub
    {
        private Club.ChampsPoona champsPoona;
        private Club.ChampsCobad champsCobad = new Club.ChampsCobad();

        private IRepertoireClubs repertoireClubs;
        internal CreateurClub(IRepertoireClubs repertoireClubs)
        {
            this.repertoireClubs = repertoireClubs;
        }

        public CreateurClub DontLeNumeroEst(string numero)
        {
            if (this.champsPoona == null)
                this.champsPoona = new Club.ChampsPoona(numero);
            else
                this.champsPoona.Numero = numero;
            return this;
        }

        public CreateurClub DontLesChampsPoonaSont(Club.ChampsPoona champsPoona)
        {
            this.champsPoona = champsPoona;
            return this;
        }

        public Club Creer()
        {
            if (champsPoona == null)
                throw new ArgumentNullException("Il faut specifier les champs poona ou au moins le numero du club");
            else if (repertoireClubs.Existe(champsPoona.Numero))
                throw new DuplicationException();

            var club = new Club(champsPoona, champsCobad);
            repertoireClubs.MettreAJour(club);
            return club;
        }
    }
}
