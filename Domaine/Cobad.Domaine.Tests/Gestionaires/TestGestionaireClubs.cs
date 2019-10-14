using Cobad.Domaine.Metier;
using Cobad.Domaine.Metier.Createurs;
using Cobad.Domaine.Metier.Filtres;
using Cobad.Domaine.Metier.Modificateurs;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cobad.Domaine.Tests
{
    public class TestGestionaireClubs
    {
        IGestionaireClubs gestionaireClubs = new FrontiereCobad(new Mock<IFrontierePersistance>().Object).GestionaireClubs;


        [Fact]
        public void obtenir_filtre_de_club_renvoie_un_filtre_de_club()
        {
            Assert.IsType<FiltreClub>(gestionaireClubs.ObtenirFiltreDeClub());
        }

        [Fact]
        public void obtenir_createur_de_club_renvoie_un_createur_de_club()
        {
            Assert.IsType<CreateurClub>(gestionaireClubs.ObtenirCreateurDeClub());
        }

        [Fact]
        public void obtenir_modificateur_de_club_renvoie_un_modificateur_de_club()
        {
            Assert.IsType<ModificateurClub>(gestionaireClubs.ObtenirModificateurDeClub());
        }
    }
}
