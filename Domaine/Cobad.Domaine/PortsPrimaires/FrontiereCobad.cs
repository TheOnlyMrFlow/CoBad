using Cobad.Domaine.Metier;
using Cobad.Domaine.PortsSecondaires;
using Cobad.Domaine.PortsSecondaires.AccesPoona;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;

namespace Cobad.Domaine
{
    public class FrontiereCobad : IFrontiereCobad
    {
        public IGestionaireClubs GestionaireClubs { get; private set; }
        public IGestionaireCollectifs GestionaireCollectifs { get; private set; }
        public IGestionaireJoueurs GestionaireJoueurs { get; private set; }
        public IAccesseurPoona AccesseurPoona { get; private set; }

        public IImporteurDeCompetition ImporteurCompetition { get; private set; }

        public FrontiereCobad(IFrontierePersistance frontierePersistance, IAccesseurPoona accesseurPoona, IImporteurDeCompetition importeurCompetition)
        {
            GestionaireClubs = new GestionaireClubs(frontierePersistance.RepertoireClubs);
            GestionaireCollectifs = new GestionaireCollectifs(frontierePersistance.RepertoireCollectifs);
            GestionaireJoueurs = new GestionaireJoueurs(frontierePersistance.RepertoireJoueurs, frontierePersistance.RepertoireClubs);

            AccesseurPoona = accesseurPoona;
            ImporteurCompetition = importeurCompetition;

            frontierePersistance
                .RepertoireClubs
                .MettreAJourOuAjouterSiExistePas(
                    new Club("0")
                    {
                        Numero = "0",
                        champsPropresAPoona= new Club.ChampsPoona { Nom = "Club inconnu" }
                    }
                );

            frontierePersistance
                .RepertoireJoueurs
                .MettreAJourOuAjouterSiExistePas(
                    new Joueur(0, "0")
                    {
                        Licence = 0,
                        NumeroClub = "0",
                        ChampsPropresAPoona = new Joueur.ChampsPoona { Nom = "Joueur inconnu"}
                    }
                );
        }
    }
}
