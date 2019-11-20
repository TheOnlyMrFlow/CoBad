using System;
using Xunit;
using Moq;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System.Xml.Linq;
using FluentAssertions;
using System.Linq;
using Cobad.Domaine;

namespace ImportCompetitionXML.Tests
{
    public class TestImporteurDeCompetitionParFichierXML
    {

        ImporteurDeCompetitionParFichierXML importeurDeCompetition;

        string cheminFichierExemple = @"C:\\Users\\comte\\Documents\\Kata Atelier\\18.LIFB.93_TI.D._006.xml";

        public TestImporteurDeCompetitionParFichierXML()
        {



            var moyenDePersistance = new Mock<IFrontierePersistance>();
                moyenDePersistance
                .Setup(x => x.RepertoireJoueurs.ObtenirJoueurParLicense(It.IsAny<int>()))
                .Returns(new Joueur(1, "1"));

            importeurDeCompetition = new ImporteurDeCompetitionParFichierXML(moyenDePersistance.Object);
        }

        [Fact]
        public void le_nom_de_la_competition_est_bon()
        {   

            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Nom.Should().Be("TNT4");
        }

        [Fact]
        public void la_date_de_la_competition_est_bonne()
        {

            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Date.Year.Should().Be(2019);
            competition.Date.Month.Should().Be(3);
            competition.Date.Day.Should().Be(30);
        }

        [Fact]
        public void le_nombre_de_tableaux_est_bon()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.Should().HaveCount(22);
        }

        [Fact]
        public void le_nom_des_tableaux_est_bon()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.First().Nom.Should().Be("Simple Homme Benjamin TOP C");
            competition.Tableaux.ElementAt(1).Nom.Should().Be("Simple Homme Benjamin TOP A");
            competition.Tableaux.Last().Nom.Should().Be("Double Dame Cadets");
        }

        [Fact]
        public void le_id_des_tableaux_est_bon()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.First().Id.Should().Be(350474);
            competition.Tableaux.ElementAt(1).Id.Should().Be(350992);
            competition.Tableaux.Last().Id.Should().Be(350489);
        }

        [Fact]
        public void la_categorie_des_tableaux_est_bonnne()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.First().Categorie.Should().Be("Ben");
            competition.Tableaux.ElementAt(3).Categorie.Should().Be("Min");
            competition.Tableaux.Last().Categorie.Should().Be("Cad");
        }

        [Fact]
        public void le_niveau_des_tableaux_est_bon()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.First().Niveau.Should().Be("R4");
            competition.Tableaux.ElementAt(1).Niveau.Should().Be("N1");
            competition.Tableaux.Last().Niveau.Should().Be("R4");
        }

        [Fact]
        public void le_nombre_de_round_par_tableau_est_bon()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.First().Rounds.Should().HaveCount(5);
        }

        [Fact]
        public void le_nom_des_rounds_est_bon()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.First().Rounds.First().Nom.Should().Be("Finale");
            competition.Tableaux.First().Rounds.Last().Nom.Should().Be("Poule C");
        }

        [Fact]
        public void le_id_des_rounds_est_bon()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.First().Rounds.First().Id.Should().Be(4421650);
            competition.Tableaux.First().Rounds.Last().Id.Should().Be(442164); 
        }

        [Fact]
        public void le_nombre_de_matchs_par_round_est_bon()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.First().Rounds.First().Matchs.Should().HaveCount(1);
            competition.Tableaux.First().Rounds.ElementAt(1).Matchs.Should().HaveCount(2);
        }

        [Fact]
        public void le_match_est_abandonné()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.First().Rounds.ElementAt(2).Matchs.ElementAt(1).Abandon.Should().BeTrue();
        }

        [Fact]
        public void le_match_est_forfait()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            competition.Tableaux.ElementAt(11).Rounds.First().Matchs.First().Forfait.Should().BeTrue();
        }

        [Fact]
        public void le_score_est_bon()
        {
            var competition = importeurDeCompetition.ExtraireCompetitionDe(XDocument.Load(cheminFichierExemple));
            var match = competition.Tableaux.ElementAt(12).Rounds.First().Matchs.ElementAt(1);
            var scoresA = match.ScoresA;
            var scoresB = match.ScoresB;
            scoresA.Should().HaveCount(2);
            scoresB.Should().HaveCount(2);
            scoresA[0].Should().Be(21);
            scoresA[1].Should().Be(21);
            scoresB[0].Should().Be(13);
            scoresB[1].Should().Be(6);

        }

    }
}
