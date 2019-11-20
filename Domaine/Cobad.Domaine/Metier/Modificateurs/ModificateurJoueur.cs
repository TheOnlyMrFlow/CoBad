using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Modificateurs
{
    class ModificateurJoueur : IModificateurJoueur
    {

        private IRepertoireJoueurs repertoireJoueurs;

        private Joueur joueurAModifier;

        internal ModificateurJoueur(IRepertoireJoueurs repertoireJoueurs, int licenseDuJoueurAModifier)
        {
            this.repertoireJoueurs = repertoireJoueurs;
            this.joueurAModifier = repertoireJoueurs.ObtenirJoueurParLicense(licenseDuJoueurAModifier);
        }

        private bool sauvegarderMail = false;
        private string mail;

        private bool sauvegarderTelephone = false;
        private string telephone;

        public IModificateurJoueur ModifierLesChampsPoona(Joueur.ChampsPoona champsPoona)
        {
            joueurAModifier.ChampsPropresAPoona = champsPoona;
            return this;
        }

        public IModificateurJoueur ModifierMail(string mail)
        {
            joueurAModifier.Mail = mail;
            return this;
        }

        public IModificateurJoueur ModifierTelephone(string telephone)
        {
            joueurAModifier.Tel = telephone;
            return this;
        }
        public Joueur Sauvegarder()
        {
            repertoireJoueurs.MettreAJour(joueurAModifier);
            return joueurAModifier;
        }

       
    }
}
