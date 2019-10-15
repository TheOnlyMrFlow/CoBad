using Cobad.Domaine.Metier;
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
    public class TestModificateurClub
    {
        private IGestionaireClubs gestionaireClubs;

        private Personnel personnelDeDepart;

        private string numeroClubQuiExiste = "LIFB.93.05.025";

        public TestModificateurClub()
        {

            personnelDeDepart = new Personnel(Personnel.Role.Encadrant, "Foo Bar", "0642069000", "0642069000", "foo@bar.com");

            var club = new Club(
                            numeroClubQuiExiste,
                            new Club.ChampsPoona(
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
                                new List<Personnel> {
                                    personnelDeDepart
                                }
                            );

            var mockRepertoireClub = new Mock<IRepertoireClubs>();

            mockRepertoireClub
                .Setup(x => x.Existe(It.IsAny<string>()))
                .Returns(false);

            mockRepertoireClub
                .Setup(x => x.Existe(numeroClubQuiExiste))
                .Returns(true);

            mockRepertoireClub
                .Setup(x => x.ObtenirClubParNumero(numeroClubQuiExiste))
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
            Assert.Throws<ElementNonExistantException>(() => gestionaireClubs.ObtenirModificateurDeClub("67876"));
        }

        [Fact]
        public void ajouter_personnel_ajoute_le_personnel()
        {
            var personnel = new Personnel(Personnel.Role.Dirigeant, "John Doe", "0642069000", "0642069000", "john@doe.com");

            var club = gestionaireClubs.ObtenirModificateurDeClub(numeroClubQuiExiste).AjouterPersonnel(personnel).Sauvegarder();
            Assert.Contains(personnel, club.Personnel);

        }

        [Fact]
        public void retirer_personnel_retire_le_personnel()
        {
            var club = gestionaireClubs.ObtenirModificateurDeClub("LIFB.93.05.025").RetirerPersonnel("Foo Bar").Sauvegarder();
            Assert.DoesNotContain(personnelDeDepart, club.Personnel);

        }





    }
}
