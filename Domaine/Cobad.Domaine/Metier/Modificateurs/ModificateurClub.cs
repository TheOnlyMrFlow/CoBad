using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Modificateurs
{
    internal class ModificateurClub : IModificateurClub
    {

        private IRepertoireClubs repertoireClubs;

        private Club clubAModifier;

        public IModificateurClub ModifierLesChampsPoona(Club.ChampsPoona champsPoona)
        {
            this.clubAModifier.champsPropresAPoona = champsPoona;
            return this;
        }

        internal ModificateurClub(IRepertoireClubs repertoireClubs, string numeroDuClubAModifier)
        {
            this.repertoireClubs = repertoireClubs;
            this.clubAModifier = repertoireClubs.ObtenirClubParNumero(numeroDuClubAModifier);
        }

        public IModificateurClub AjouterPersonnel(Personnel personnel)
        {
            clubAModifier.Personnel.Add(personnel);
            return this;
        }


        public IModificateurClub RetirerPersonnel(string nom)
        {
            clubAModifier.Personnel.RemoveAll(personnel => personnel.Nom == nom);
            return this;
        }

        public Club Sauvegarder()
        {
            repertoireClubs.MettreAJour(clubAModifier);
            return clubAModifier;
        }
    }
}
