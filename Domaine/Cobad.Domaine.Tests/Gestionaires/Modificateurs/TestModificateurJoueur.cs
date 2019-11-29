using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;
using Cobad.Domaine.PortsSecondaires;
using Cobad.Domaine.PortsSecondaires.AccesPoona;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cobad.Domaine.Tests
{
    public class TestModificateurJoueur
    {
        private IGestionaireJoueurs gestionaireJoueurs;

        private Personnel personnelDeDepart;

        private int licenseJoueurQuiExiste = 123456789;
        private int licenseJoueurQuiExistePas = 987654321;

        private string telDeDepart = "0644234341";
        private string mailDeDepart = "john@doe.com";

        public TestModificateurJoueur()
        {

            var mockRepertoireJoueurs = new Mock<IRepertoireJoueurs>();

            var joueur = new Joueur(
                licenseJoueurQuiExiste,
                It.IsAny<string>(),
                new Joueur.ChampsPoona(
                    "John",
                    "Doe",
                    It.IsAny<int>(),
                    It.IsAny<char>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Categorie>(),
                    It.IsAny<string>(),
                    It.IsAny<float>(),
                    It.IsAny<string>(),
                    It.IsAny<float>(),
                    It.IsAny<string>(),
                    It.IsAny<float>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<Plume>()
                    )
                );

            joueur.Mail = mailDeDepart;
            joueur.Tel = telDeDepart;

            mockRepertoireJoueurs
                .Setup(x => x.Existe(It.IsAny<int>()))
                .Returns(false);

            mockRepertoireJoueurs
                .Setup(x => x.Existe(licenseJoueurQuiExiste))
                .Returns(true);

            mockRepertoireJoueurs
                .Setup(x => x.ObtenirJoueurParLicense(licenseJoueurQuiExiste))
                .Returns(joueur);


            var mockFrontierePersistence = new Mock<IFrontierePersistance>();
            mockFrontierePersistence
                .Setup(x => x.RepertoireJoueurs)
                .Returns(mockRepertoireJoueurs.Object);

            this.gestionaireJoueurs = new FrontiereCobad(mockFrontierePersistence.Object, new Mock<IAccesseurPoona>().Object, new Mock<IImporteurDeCompetition>().Object).GestionaireJoueurs;

            
        }

        [Fact]
        public void leve_une_exception_si_joueur_existe_pas()
        {
            Assert.Throws<ElementNonExistantException>(() => gestionaireJoueurs.ObtenirModificateurDeJoueur(licenseJoueurQuiExistePas));
        }

        [Fact]
        public void modifier_le_mail_fonctionne()
        {

            var modificateurJoueur = gestionaireJoueurs.ObtenirModificateurDeJoueur(licenseJoueurQuiExiste);

            var newMail = "foo@bar.fr";

            var joueurModifie = modificateurJoueur.ModifierMail(newMail).Sauvegarder();
            
            Assert.Equal(newMail, joueurModifie.Mail);

        }

        [Fact]
        public void modifier_le_tel_fonctionne()
        {

            var modificateurJoueur = gestionaireJoueurs.ObtenirModificateurDeJoueur(licenseJoueurQuiExiste);

            var newTel = "0978564329";

            var joueurModifie = modificateurJoueur.ModifierTelephone(newTel).Sauvegarder();

            Assert.Equal(newTel, joueurModifie.Tel);

        }





    }
}
