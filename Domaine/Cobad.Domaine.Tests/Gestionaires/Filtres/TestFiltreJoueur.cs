using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.PortsSecondaires.AccesPoona;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cobad.Domaine.Tests
{
    public class TestFiltreJoueur
    {

        private Joueur joueur1, joueur2, joueur3;
        private string clubDuJoueur1 = "1", clubDesJoueurs2et3 = "2";

        IFiltreJoueur filtreJoueur;

        public TestFiltreJoueur()
        {

            this.joueur1 =
                new Joueur(
                    1,
                    clubDuJoueur1,
                    new Joueur.ChampsPoona(
                        "Doe",
                        "John",
                        It.IsAny<int>(),
                        'h',
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        "john@doe.com",
                        Categorie.Benjamin2,
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

            this.joueur2 =
                new Joueur(
                    2,
                    clubDesJoueurs2et3,
                    new Joueur.ChampsPoona(
                        "Bar",
                        "Foo",
                        It.IsAny<int>(),
                        'h',
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        "foor@bar.com",
                        Categorie.Benjamin1,
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

            this.joueur3 =
                new Joueur(
                    3,
                    clubDesJoueurs2et3,
                    new Joueur.ChampsPoona(
                        "Bar",
                        "John",
                        It.IsAny<int>(),
                        'f',
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        "john@bar.com",
                        Categorie.Benjamin2,
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

            this.joueur3.Mail = "johnbar@cobad.com";



            var mockRepertoireJoueurs = new Mock<IRepertoireJoueurs>();
            mockRepertoireJoueurs
                .Setup(x => x.ObtenirTousLesJoueurs())
                .Returns(new List<Joueur> { joueur1, joueur2, joueur3 });        

            var mockFrontierePersistence = new Mock<IFrontierePersistance>();
            mockFrontierePersistence
                .Setup(x => x.RepertoireJoueurs)
                .Returns(mockRepertoireJoueurs.Object);

            this.filtreJoueur = new FrontiereCobad(mockFrontierePersistence.Object, new Mock<IAccesseurPoona>().Object).GestionaireJoueurs.ObtenirFiltreDeJoueur();
        }


        [Fact]
        public void ordonner_par_defaut_renvoie_tous_les_joueurs_du_repertoire()
        {
            var expectedJoueurs = new HashSet<Joueur>{ joueur1, joueur2, joueur3 };
            var actualJoueurs = new HashSet<Joueur>(filtreJoueur.OrdonnerParDefaut());
            Assert.True(expectedJoueurs.SetEquals(actualJoueurs));
        }

        [Fact]
        public void ordonner_par_nom_renvoie_les_joueurs_ordonnes_par_nom()
        {
            var expectedJoueurs = new List<Joueur> { joueur2, joueur3, joueur1 };
            var actualJoueurs = filtreJoueur.OrdonnerParNom();
            Assert.Equal(expectedJoueurs, actualJoueurs);
        }

        [Fact]
        public void generer_mailing_liste_renvoie_mail_cobad_en_priorite_et_mail_poona_sinon()
        {
            var expectedMails = new[] { "john@doe.com", "foor@bar.com", "johnbar@cobad.com" };
            var actualMails = filtreJoueur.GenererMailingList(";");
            foreach(var expectedMail in expectedMails)
            {
                Assert.Contains(expectedMail, actualMails);
            }
        }

        [Fact]
        public void filtrer_par_sexe_ne_renvoie_que_les_joueurs_avec_le_bon_sexe()
        {
            var expectedJoueurs = new HashSet<Joueur> { joueur1, joueur2 };
            var actualJoueurs = new HashSet<Joueur>(filtreJoueur.FiltrerparSexe('h').OrdonnerParDefaut());
            Assert.True(expectedJoueurs.SetEquals(actualJoueurs));
        }

        [Fact]
        public void filtrer_par_club_ne_renvoie_que_les_joueurs_avec_le_bon_club()
        {
            var expectedJoueurs = new List<Joueur> { joueur1 };
            var actualJoueurs = filtreJoueur.FiltrerParClub(clubDuJoueur1).OrdonnerParDefaut();
            Assert.Equal(expectedJoueurs, actualJoueurs);
        }

        [Fact]
        public void filtrer_par_categorie_ne_renvoie_que_les_joueurs_avec_la_bonne_categorie()
        {
            var expectedJoueurs = new HashSet<Joueur> { joueur1, joueur3 };
            var actualJoueurs = new HashSet<Joueur>(filtreJoueur.FiltrerParCategorie(Categorie.Benjamin2).OrdonnerParDefaut());
            Assert.True(expectedJoueurs.SetEquals(actualJoueurs));
        }

    }
}
