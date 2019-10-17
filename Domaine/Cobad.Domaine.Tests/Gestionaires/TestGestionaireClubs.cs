//using Cobad.Domaine.Metier;
//using Cobad.Domaine.Metier.Createurs;
//using Cobad.Domaine.Metier.Exceptions;
//using Cobad.Domaine.Metier.Filtres;
//using Cobad.Domaine.Metier.Modificateurs;
//using Cobad.Domaine.PortsSecondaires.AccesPoona;
//using Cobad.Domaine.PortsSecondaires.Persistence;
//using Moq;
//using System;
//using System.Collections.Generic;
//using Xunit;

//namespace Cobad.Domaine.Tests
//{
//    public class TestGestionaireClubs
//    {
//        IGestionaireClubs gestionaireClubs;
//        private string numeroClubQuiExisteDeja = "LIFB.93.05.025";
//        private string numeroClubQuiExistePas = "LIFB.93.05.026";

//        public TestGestionaireClubs()
//        {
//            var mockRepertoireClubs = new Mock<IRepertoireClubs>();

//            mockRepertoireClubs
//                .Setup(x => x.Existe(It.IsAny<string>()))
//                .Returns(false);

//            mockRepertoireClubs
//                .Setup(x => x.Existe(numeroClubQuiExisteDeja))
//                .Returns(true);

//            var mockFrontierePersistance = new Mock<IFrontierePersistance>();

//            mockFrontierePersistance
//                .Setup(x => x.RepertoireClubs)
//                .Returns(mockRepertoireClubs.Object);

//            gestionaireClubs = new FrontiereCobad(mockFrontierePersistance.Object, new Mock<IAccesseurPoona>().Object).GestionaireClubs;
//        }

//        [Fact]
//        public void obtenir_filtre_de_club_renvoie_un_filtre_de_club()
//        {
//            Assert.IsType<FiltreClub>(gestionaireClubs.ObtenirFiltreDeClub());
//        }

//        [Fact]
//        public void obtenir_createur_de_club_renvoie_un_createur_de_club()
//        {
//            Assert.IsType<CreateurClub>(gestionaireClubs.ObtenirCreateurDeClub());
//        }

//        [Fact]
//        public void obtenir_modificateur_de_club_avec_numero_club_non_existant_leve_une_exception()
//        {
//            Assert.Throws<ElementNonExistantException>(() => gestionaireClubs.ObtenirModificateurDeClub(numeroClubQuiExistePas));
//        }

//        [Fact]
//        public void obtenir_modificateur_de_club_renvoie_un_modificateur_de_club()
//        {
//            Assert.IsType<ModificateurClub>(gestionaireClubs.ObtenirModificateurDeClub(numeroClubQuiExisteDeja));
//        }
//    }
//}
