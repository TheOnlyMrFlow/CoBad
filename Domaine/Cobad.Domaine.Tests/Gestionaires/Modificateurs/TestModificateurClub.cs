using Cobad.Domaine.Metier;
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
    public class TestModificateurClub
    {
        private IGestionaireClubs gestionaireClubs;

        private Exception ExceptionThrownIfNotFound = new Exception();

        private Personnel personnelDeDepart;

        public TestModificateurClub()
        {

            personnelDeDepart = new Personnel(Personnel.Role.Encadrant, "Foo Bar", "0642069000", "0642069000", "foo@bar.com");

            var club = new Club(
                            new Club.ChampsPoona(
                                "LIFB.93.05.025",
                                new Adresse(),
                                "Association Badminton Seine St Denis",
                                "APSAD93",
                                "Bobigny",
                                "93000",
                                "Foo Bar",
                                true,
                                "",
                                "",
                                "",
                                ""
                                ),
                            new Club.ChampsCobad(
                                new List<Personnel> {
                                    personnelDeDepart
                                })
                            );

            var mockRepertoireClub = new Mock<IRepertoireClubs>();
            mockRepertoireClub
                .Setup(x => x.ObtenirTousLesClubs())
                .Returns(new List<Club> { club });

            mockRepertoireClub
                .Setup(x => x.ObtenirClubParNumero(It.IsAny<string>()))
                .Throws(ExceptionThrownIfNotFound);

            mockRepertoireClub
                .Setup(x => x.ObtenirClubParNumero(club.champsPropresAPoona.Numero))
                .Returns(club);


            var mockFrontierePersistence = new Mock<IFrontierePersistance>();
            mockFrontierePersistence
                .Setup(x => x.RepertoireClubs)
                .Returns(mockRepertoireClub.Object);

            this.gestionaireClubs = new FrontiereCobad(mockFrontierePersistence.Object).GestionaireClubs;

            
        }

        [Fact]
        public void leve_une_exception_si_club_existe_pas()
        {
            Exception e = Assert.Throws<Exception>(() => gestionaireClubs.ObtenirModificateurDeClub("67876"));
            Assert.Equal(e, ExceptionThrownIfNotFound);
        }

        [Fact]
        public void ajouter_personnel_ajoute_le_personnel()
        {
            var personnel = new Personnel(Personnel.Role.Dirigeant, "John Doe", "0642069000", "0642069000", "john@doe.com");

            var club = gestionaireClubs.ObtenirModificateurDeClub("LIFB.93.05.025").AjouterPersonnel(personnel).Sauvegarder();
            Assert.Contains(personnel, club.champsPropresACobad.Personnel);

        }

        [Fact]
        public void retirer_personnel_retire_le_personnel()
        {
            var club = gestionaireClubs.ObtenirModificateurDeClub("LIFB.93.05.025").RetirerPersonnel("Foo Bar").Sauvegarder();
            Assert.DoesNotContain(personnelDeDepart, club.champsPropresACobad.Personnel);

        }





    }
}
