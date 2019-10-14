using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cobad.Domaine.Tests
{
    public class TestFiltreClub
    {

        private Club club1, club2, club3;

        IFiltreClub filtreClub;

        public TestFiltreClub()
        {

            this.club1 = new Club(
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
                                )
                            );


            this.club2 = new Club(
                            new Club.ChampsPoona(
                                "LIFB.93.98.018",
                                new Adresse(),
                                "Athletic Club De Bobigny",
                                "ACB",
                                "Bobigny",
                                "93000",
                                "John Doe",
                                false,
                                "",
                                "",
                                "",
                                ""
                                )
                            );

            this.club3 = new Club(
                            new Club.ChampsPoona(
                                "LIFB.93.06.040",
                                new Adresse(),
                                "Association Badminton Romainvillois",
                                "ABR",
                                "Romainville",
                                "93230",
                                "John Doe",
                                false,
                                "",
                                "",
                                "",
                                ""
                                )
                            );

            var mockRepertoireClub = new Mock<IRepertoireClubs>();
            mockRepertoireClub
                .Setup(x => x.ObtenirTousLesClubs())
                .Returns(new List<Club> { club1, club2, club3 });        

            var mockFrontierePersistence = new Mock<IFrontierePersistance>();
            mockFrontierePersistence
                .Setup(x => x.RepertoireClubs)
                .Returns(mockRepertoireClub.Object);

            this.filtreClub = new FrontiereCobad(mockFrontierePersistence.Object).GestionaireClubs.ObtenirFiltreDeClub();
        }


        [Fact]
        public void ordonner_par_defaut_renvoie_tous_les_clubs_du_repertoire()
        {
            var expectedClubs = new HashSet<Club>{ club1, club2, club3 };
            var actualClubs = new HashSet<Club>(filtreClub.OrdonnerParDefaut());
            Assert.True(expectedClubs.SetEquals(actualClubs));
        }

        [Fact]
        public void ordonner_par_nom_renvoie_les_clubs_ordonnes_par_nom()
        {
            var expectedClubs = new List<Club> { club3, club1, club2 };
            var actualClubs = filtreClub.OrdonnerParNom();
            Assert.Equal(expectedClubs, actualClubs);
        }

        [Fact]
        public void ordonner_par_numero_renvoie_les_clubs_ordonnes_par_numero()
        {
            var expectedClubs = new List<Club> { club1, club3, club2 };
            var actualClubs = filtreClub.OrdonnerParNumero();
            Assert.Equal(expectedClubs, actualClubs);
        }

        [Fact]
        public void ordonner_par_sigle_renvoie_les_clubs_ordonnes_par_sigle()
        {
            var expectedClubs = new List<Club> { club3, club2, club1 };
            var actualClubs = filtreClub.OrdonnerParSigle();
            Assert.Equal(expectedClubs, actualClubs);
        }

        [Fact]
        public void filtrer_par_nom_ne_renvoie_que_les_clubs_avec_le_bon_nom()
        {
            var expectedClubs = new List<Club> { club3 };
            var actualClubs = filtreClub.FiltrerParNom("Association Badminton Romainvillois").OrdonnerParDefaut();
            Assert.Equal(expectedClubs, actualClubs);
        }

        [Fact]
        public void filtrer_par_sigle_ne_renvoie_que_les_clubs_avec_le_bon_sigle()
        {
            var expectedClubs = new List<Club> { club1 };
            var actualClubs = filtreClub.FiltrerParSigle("APSAD93").OrdonnerParDefaut();
            Assert.Equal(expectedClubs, actualClubs);
        }

        [Fact]
        public void filtrer_par_nom_avec_nom_inexistant_renvoie_vide()
        {
            var actualClubs = filtreClub.FiltrerParNom("Un club qui nexiste pas").OrdonnerParDefaut();
            Assert.Empty(actualClubs);
        }

    }
}
