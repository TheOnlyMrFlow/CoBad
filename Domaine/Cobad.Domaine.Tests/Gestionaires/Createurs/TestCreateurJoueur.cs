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
    public class TestCreateurJoueur
    {
        private ICreateurJoueur createurJoueur;

        private int licenseJoueurQuiExisteDeja = 123456789;
        private int licenseJoueurQuiExistePas = 987654321;

        public TestCreateurJoueur()
        {


            var mockRepertoireJoueurs = new Mock<IRepertoireJoueurs>();

            mockRepertoireJoueurs
                .Setup(x => x.Existe(It.IsAny<int>()))
                .Returns(false);

            mockRepertoireJoueurs
                .Setup(x => x.Existe(licenseJoueurQuiExisteDeja))
                .Returns(true);


            var mockFrontierePersistence = new Mock<IFrontierePersistance>();
            mockFrontierePersistence
                .Setup(x => x.RepertoireJoueurs)
                .Returns(mockRepertoireJoueurs.Object);

            this.createurJoueur = new FrontiereCobad(mockFrontierePersistence.Object).GestionaireJoueurs.ObtenirCreateurDeJoueur();
            
        }

        [Fact]
        public void leve_une_exception_si_numero_pas_specifie()
        {
            Assert.Throws<ArgumentNullException>(() => createurJoueur.Creer());
        }

        [Fact]
        public void leve_une_exception_si_joueur_existe_deja()
        {
            Assert.Throws<DuplicationException>(() => createurJoueur.DontLaLicenceEst(licenseJoueurQuiExisteDeja).Creer());
        }

        [Fact]
        public void fixer_la_license_fonctionne()
        {
            var joueurRenvoye = createurJoueur.DontLaLicenceEst(licenseJoueurQuiExistePas).Creer();
            Assert.Equal(licenseJoueurQuiExistePas, joueurRenvoye.Licence);
        }

        [Fact]
        public void fixer_les_champs_poona_fonctionne()
        {
            var champs = new Joueur.ChampsPoona();
            champs.Nom = "Foo Bar";
            var joueurRenvoye = createurJoueur
                .DontLaLicenceEst(licenseJoueurQuiExistePas)
                .DontLesChampsPoonaSont(champs)
                .Creer();
            Assert.Equal(champs, joueurRenvoye.ChampsPropresAPoona);
            Assert.Equal("Foo Bar", joueurRenvoye.ChampsPropresAPoona.Nom);
        }

    }
}
