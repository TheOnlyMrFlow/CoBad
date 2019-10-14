﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Modificateurs
{
    public class ModificateurJoueur : IModificateurJoueur
    {

        internal ModificateurJoueur() { }

        private bool sauvegarderMail = false;
        private string mail;

        private bool sauvegarderTelephone = false;
        private string telephone;

        public IModificateurJoueur SetMail(string mail)
        {
            sauvegarderMail = true;
            this.mail = mail;
            return this;
        }

        public IModificateurJoueur SetTelephone(string telephone)
        {
            sauvegarderTelephone = true;
            this.telephone = telephone;
            return this;
        }
        public Joueur Sauvegarder()
        {
            throw new NotImplementedException();
        }
    }
}
