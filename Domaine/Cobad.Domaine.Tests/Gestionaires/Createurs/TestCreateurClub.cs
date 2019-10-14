using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Createurs;
using Cobad.Domaine.Metier.Exceptions;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cobad.Domaine.Tests
{
    public class TestCreateurClub
    {
        private ICreateurClub createurClub;

        private string numeroClubQuiExisteDeja = "LIFB.93.05.025";
        private string numeroClubQuiExistePas = "LIFB.93.05.026";

        public TestCreateurClub()
        {


            var mockRepertoireClub = new Mock<IRepertoireClubs>();

            mockRepertoireClub
                .Setup(x => x.Existe(It.IsAny<string>()))
                .Returns(false);

            mockRepertoireClub
                .Setup(x => x.Existe(numeroClubQuiExisteDeja))
                .Returns(true);


            var mockFrontierePersistence = new Mock<IFrontierePersistance>();
            mockFrontierePersistence
                .Setup(x => x.RepertoireClubs)
                .Returns(mockRepertoireClub.Object);

            this.createurClub = new FrontiereCobad(mockFrontierePersistence.Object).GestionaireClubs.ObtenirCreateurDeClub();
            
        }

        [Fact]
        public void leve_une_exception_si_club_existe_deja()
        {
            var champs = new Club.ChampsPoona(numeroClubQuiExisteDeja);
            Assert.Throws<DuplicationException>(() => createurClub.DontLesChampsPoonaSont(champs).Creer());
        }

        [Fact]
        public void retourne_le_bon_club()
        {
            var champs = new Club.ChampsPoona(numeroClubQuiExistePas);
            var clubRenvoye = createurClub.DontLesChampsPoonaSont(champs).Creer();
            Assert.Equal(champs, clubRenvoye.champsPropresAPoona);

        }

    }
}
