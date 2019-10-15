using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.PortsSecondaires.AccesPoona;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cobad.Domaine.Tests
{
    public class TestFrontieresCobad
    {
        FrontiereCobad frontiereCobad = new FrontiereCobad(new Mock<IFrontierePersistance>().Object, new Mock<IAccesseurPoona>().Object);


        [Fact]
        public void obtenir_gestionaire_de_club_renvoie_un_gestionaire_de_club()
        {
            Assert.IsType<GestionaireClubs>(frontiereCobad.GestionaireClubs);
        }

        [Fact]
        public void obtenir_gestionaire_de_collectif_renvoie_un_gestionaire_de_collectif()
        {
            Assert.IsType<GestionaireCollectifs>(frontiereCobad.GestionaireCollectifs);
        }

        [Fact]
        public void obtenir_gestionaire_de_joueur_renvoie_un_gestionaire_de_joueur()
        {
            Assert.IsType<GestionaireJoueurs>(frontiereCobad.GestionaireJoueurs);
        }
    }
}
