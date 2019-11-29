using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Createurs;
using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;
using Cobad.Domaine.PortsSecondaires.AccesPoona;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Cobad.Domaine.PortsSecondaires;

namespace Cobad.Domaine.Tests
{
    public class TestCreateurJoueur
    {
        private ICreateurJoueur createurJoueur;

        private int licenseJoueurQuiExisteDeja = 123456789;
        private int licenseJoueurQuiExistePas = 987654321;

        private string numeroClubQuiExiste = "LIFB.93.05.025";
        private string numeroClubQuiExistePas = "LIFB.93.05.026";

        public TestCreateurJoueur()
        {


            var mockRepertoireJoueurs = new Mock<IRepertoireJoueurs>();
            mockRepertoireJoueurs
                .Setup(x => x.Existe(It.IsAny<int>()))
                .Returns(false);
            mockRepertoireJoueurs
                .Setup(x => x.Existe(licenseJoueurQuiExisteDeja))
                .Returns(true);

            var mockRepertoireClubs = new Mock<IRepertoireClubs>();
            mockRepertoireClubs
                .Setup(x => x.Existe(It.IsAny<string>()))
                .Returns(false);
            mockRepertoireClubs
                .Setup(x => x.Existe(numeroClubQuiExiste))
                .Returns(true);

            var mockFrontierePersistence = new Mock<IFrontierePersistance>();
            mockFrontierePersistence
                .Setup(x => x.RepertoireJoueurs)
                .Returns(mockRepertoireJoueurs.Object);
            mockFrontierePersistence
                .Setup(x => x.RepertoireClubs)
                .Returns(mockRepertoireClubs.Object);

            this.createurJoueur = new FrontiereCobad( mockFrontierePersistence.Object, new Mock<IAccesseurPoona>().Object, new Mock<IImporteurDeCompetition>().Object).GestionaireJoueurs.ObtenirCreateurDeJoueur();
            
        }

        [Fact]
        public void leve_une_exception_si_license_pas_specifie()
        {
            Assert.Throws<ArgumentNullException>(() => 
                createurJoueur
                .DontLeClubPorteLeNumero(numeroClubQuiExiste)
                .Creer());
        }

        [Fact]
        public void leve_une_exception_si_club_pas_specifie()
        {
            Assert.Throws<ArgumentNullException>(() => 
                createurJoueur
                .DontLaLicenceEst(licenseJoueurQuiExistePas)
                .Creer());
        }

        [Fact]
        public void leve_une_exception_si_joueur_existe_deja()
        {
            Assert.Throws<DuplicationException>(() => 
                createurJoueur
                .DontLeClubPorteLeNumero(numeroClubQuiExiste)
                .DontLaLicenceEst(licenseJoueurQuiExisteDeja)
                .Creer());
        }

        [Fact]
        public void leve_une_exception_si_club_existe_pas()
        {
            Assert.Throws<ElementNonExistantException>(() =>
                createurJoueur
                .DontLeClubPorteLeNumero(numeroClubQuiExistePas)
                .DontLaLicenceEst(licenseJoueurQuiExistePas)
                .Creer());
        }

        [Fact]
        public void fixer_la_license_fonctionne()
        {
            var joueurRenvoye = createurJoueur
                .DontLeClubPorteLeNumero(numeroClubQuiExiste)
                .DontLaLicenceEst(licenseJoueurQuiExistePas).Creer();
            Assert.Equal(licenseJoueurQuiExistePas, joueurRenvoye.Licence);
        }

        [Fact]
        public void fixer_les_champs_poona_fonctionne()
        {
            var champs = new Joueur.ChampsPoona();
            champs.Nom = "Foo Bar";
            var joueurRenvoye = createurJoueur
                .DontLeClubPorteLeNumero(numeroClubQuiExiste)
                .DontLaLicenceEst(licenseJoueurQuiExistePas)
                .DontLesChampsPoonaSont(champs)
                .Creer();
            Assert.Equal(champs, joueurRenvoye.ChampsPropresAPoona);
            Assert.Equal("Foo Bar", joueurRenvoye.ChampsPropresAPoona.Nom);
        }

    }
}
