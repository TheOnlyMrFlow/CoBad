using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Createurs;
using Cobad.Domaine.Metier.Exceptions;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cobad.Domaine.Tests
{
    public class TestGestionaireJoueurs
    {
        IGestionaireJoueurs gestionaireJoueurs;
        private int licenseJoueurQuiExisteDeja = 123456789;
        private int licenseJoueurQuiExistePas = 987654321;

        public TestGestionaireJoueurs()
        {
            var mockRepertoireJoueurs = new Mock<IRepertoireJoueurs>();

            mockRepertoireJoueurs
                .Setup(x => x.Existe(It.IsAny<int>()))
                .Returns(false);

            mockRepertoireJoueurs
                .Setup(x => x.Existe(licenseJoueurQuiExisteDeja))
                .Returns(true);

            var mockFrontierePersistance = new Mock<IFrontierePersistance>();

            mockFrontierePersistance
                .Setup(x => x.RepertoireJoueurs)
                .Returns(mockRepertoireJoueurs.Object);

            gestionaireJoueurs = new FrontiereCobad(mockFrontierePersistance.Object).GestionaireJoueurs;
        }

        [Fact]
        public void obtenir_filtre_de_joueur_renvoie_un_filtre_de_joueur()
        {
            Assert.IsType<FiltreJoueur>(gestionaireJoueurs.ObtenirFiltreDeJoueur());
        }

        [Fact]
        public void obtenir_createur_de_joueur_renvoie_un_createur_de_joueur()
        {
            Assert.IsType<CreateurJoueur>(gestionaireJoueurs.ObtenirCreateurDeJoueur());
        }

        [Fact]
        public void obtenir_modificateur_de_joueur_avec_license_joueur_non_existant_leve_une_exception()
        {
            Assert.Throws<ElementNonExistantException>(() => gestionaireJoueurs.ObtenirModificateurDeJoueur(licenseJoueurQuiExistePas));
        }

        [Fact]
        public void obtenir_modificateur_de_joueur_renvoie_un_modificateur_de_joueur()
        {
            Assert.IsType<ModificateurJoueur>(gestionaireJoueurs.ObtenirModificateurDeJoueur(licenseJoueurQuiExisteDeja));
        }
    }
}
