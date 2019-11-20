using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.Domaine.Metier.Filtres
{
    class FiltreClub : IFiltreClub
    {

        private IRepertoireClubs repertoireClubs;

        private bool filtrerNom = false;
        private string nom = null;

        private bool filtrerSigle = false;
        private string sigle = null;

        internal FiltreClub(IRepertoireClubs repertoireClubs)
        {
            this.repertoireClubs = repertoireClubs;
        }

        public IFiltreClub FiltrerParNom(string nom)
        {
            filtrerNom = true;
            this.nom = nom;
            return this;
        }

        public IFiltreClub FiltrerParSigle(string sigle)
        {
            filtrerSigle = true;
            this.sigle = sigle;
            return this;
        }

        public IEnumerable<Club> OrdonnerParDefaut()
        {
            return ObtenirClubsQuiCorrespondentAuxFiltres();
        }

        public IEnumerable<Club> OrdonnerParNom()
        {
            return ObtenirClubsQuiCorrespondentAuxFiltres().OrderBy(club => club.champsPropresAPoona.Nom);
        }

        public IEnumerable<Club> OrdonnerParNumero()
        {
            return ObtenirClubsQuiCorrespondentAuxFiltres().OrderBy(club => club.Numero);
        }

        public IEnumerable<Club> OrdonnerParSigle()
        {
            return ObtenirClubsQuiCorrespondentAuxFiltres().OrderBy(club => club.champsPropresAPoona.Sigle);
        }

        private IEnumerable<Club> ObtenirClubsQuiCorrespondentAuxFiltres()
        {
            IEnumerable<Club> result;
            result = repertoireClubs.ObtenirTousLesClubs();
            if (filtrerNom)
                result = result.Where(club => club.champsPropresAPoona.Nom == nom);
            if (filtrerSigle)
                result = result.Where(club => club.champsPropresAPoona.Sigle == sigle);

            return result;
        }
    }
}
