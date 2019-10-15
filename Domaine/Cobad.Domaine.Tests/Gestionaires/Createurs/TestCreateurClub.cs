using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Createurs;
using Cobad.Domaine.Metier.Exceptions;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;
using Cobad.Domaine.PortsSecondaires.AccesPoona;
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

            this.createurClub = new FrontiereCobad(mockFrontierePersistence.Object, new Mock<IAccesseurPoona>().Object).GestionaireClubs.ObtenirCreateurDeClub();
            
        }

        [Fact]
        public void leve_une_exception_si_numero_pas_specifie()
        {
            //todo
            Assert.Throws<ArgumentNullException>(() => createurClub.Creer());
        }

        [Fact]
        public void leve_une_exception_si_club_existe_deja()
        {
            Assert.Throws<DuplicationException>(() => createurClub.DontLeNumeroEst(numeroClubQuiExisteDeja).Creer());
        }

        [Fact]
        public void fixer_le_numero_de_club_fonctionne()
        {
            var clubRenvoye = createurClub.DontLeNumeroEst(numeroClubQuiExistePas).Creer();
            Assert.Equal(numeroClubQuiExistePas, clubRenvoye.Numero);
        }

        [Fact]
        public void fixer_les_champs_poona_fonctionne()
        {
            var champs = new Club.ChampsPoona();
            champs.Nom = "Foo Bar";
            var clubRenvoye = createurClub
                .DontLeNumeroEst(numeroClubQuiExistePas)
                .DontLesChampsPoonaSont(champs)
                .Creer();
            Assert.Equal(champs, clubRenvoye.champsPropresAPoona);
            Assert.Equal("Foo Bar", clubRenvoye.champsPropresAPoona.Nom);
        }

    }
}
