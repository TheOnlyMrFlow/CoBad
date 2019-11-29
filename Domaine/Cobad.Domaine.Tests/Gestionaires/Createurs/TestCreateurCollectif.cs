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
    public class TestCreateurCollectif
    {
        private ICreateurCollectif createurCollectif;

        string nomCollectifQuiExisteDeja = "Croustillants";
        string nomCollectifQuiExistePas = "Croustillants2";

        public TestCreateurCollectif()
        {
            var mockRepertoireCollectifs = new Mock<IRepertoireCollectifs>();
            mockRepertoireCollectifs
                .Setup(x => x.Existe(It.IsAny<string>()))
                .Returns(false);
            mockRepertoireCollectifs
                .Setup(x => x.Existe(nomCollectifQuiExisteDeja))
                .Returns(true);

            var mockFrontierePersistence = new Mock<IFrontierePersistance>();
            mockFrontierePersistence
                .Setup(x => x.RepertoireCollectifs)
                .Returns(mockRepertoireCollectifs.Object);
            mockFrontierePersistence
                .Setup(x => x.RepertoireCollectifs)
                .Returns(mockRepertoireCollectifs.Object);

            this.createurCollectif = new FrontiereCobad(mockFrontierePersistence.Object, new Mock<IAccesseurPoona>().Object, new Mock<IImporteurDeCompetition>().Object).GestionaireCollectifs.ObtenirCreateurDeCollectif();

        }

        [Fact]
        public void leve_une_exception_si_nom_pas_specifie()
        {
            Assert.Throws<ArgumentNullException>(() =>
                createurCollectif
                .Creer());
        }

        [Fact]
        public void leve_une_exception_si_collectif_existe_deja()
        {
            Assert.Throws<DuplicationException>(() =>
                createurCollectif
                .DontLeNomEst(nomCollectifQuiExisteDeja)
                .Creer());
        }


        [Fact]
        public void fixer_le_nom_fonctionne()
        {
            var collectifRenvoye = 
                createurCollectif
                .DontLeNomEst(nomCollectifQuiExistePas)
                .Creer();
            Assert.Equal(nomCollectifQuiExistePas, collectifRenvoye.Nom);
        }

        [Fact]
        public void fixer_les_categories_fonctionne()
        {
            var collectifRenvoye =
               createurCollectif
               .DontLeNomEst(nomCollectifQuiExistePas)
               .DontLesCategoriesSont(new[] { Categorie.Junior1, Categorie.Poussin2 })
               .Creer();

            var expectedCategories = new HashSet<Categorie> { Categorie.Junior1, Categorie.Poussin2};
            var actualCategories = new HashSet<Categorie>(collectifRenvoye.Categories);

            Assert.True(expectedCategories.SetEquals(actualCategories));
        }

    }
}
