using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.Domaine.Metier.Filtres
{
    internal class FiltreJoueur : IFiltreJoueur
    {

        private IRepertoireJoueurs repertoireJoueurs;

        private bool filtrerNom = false;
        private string nom = null;

        private bool filtrerLicense = false;
        private int license = -1;

        private bool filtrerClub = false;
        private string numeroClub = null;

        private bool filtrerCategorie = false;
        private Categorie categorie = Categorie.Aucune;

        private bool filtrerSexe = false;
        private char sexe = ' ';
        internal FiltreJoueur(IRepertoireJoueurs repertoireJoueurs)
        {
            this.repertoireJoueurs = repertoireJoueurs;
        }

        public IFiltreJoueur FiltrerParNom(string nom)
        {
            this.filtrerNom = true;
            this.nom = nom;
            return this;
        }

        public IFiltreJoueur FiltrerParLicense(int license)
        {
            this.filtrerLicense = true;
            this.license = license;
            return this;
        }

        public IFiltreJoueur FiltrerParClub(string numeroClub)
        {
            this.filtrerClub = true;
            this.numeroClub = numeroClub;
            return this;
        }

        public IFiltreJoueur FiltrerParCategorie(Categorie categorie)
        {
            this.filtrerCategorie = true;
            this.categorie = categorie;
            return this;
        }

        public IFiltreJoueur FiltrerparSexe(char sexe)
        {
            this.filtrerSexe = true;
            this.sexe = sexe;
            return this;
        }

        public IEnumerable<Joueur> OrdonnerParNom()
        {
            return
                ObtenirJoueursQuiCorrespondentAuxFiltres()
                .OrderBy(joueur => joueur.ChampsPropresAPoona.Nom + joueur.ChampsPropresAPoona.Prenom);
        }

        public IEnumerable<Joueur> OrdonnerParDefaut()
        {
            return ObtenirJoueursQuiCorrespondentAuxFiltres();
        }

        private IEnumerable<Joueur> ObtenirJoueursQuiCorrespondentAuxFiltres()
        {

        IEnumerable<Joueur> result;
            result = repertoireJoueurs.ObtenirTousLesJoueurs();
            if (filtrerNom)
                result = result.Where(joueur => joueur.ChampsPropresAPoona.Nom == nom);
            if (filtrerLicense)
                result = result.Where(joueur => joueur.Licence == license);
            if (filtrerClub)
                result = result.Where(joueur => joueur.NumeroClub == numeroClub);
            if (filtrerCategorie)
                result = result.Where(joueur => joueur.ChampsPropresAPoona.Categorie == categorie);
            if (filtrerSexe)
                result = result.Where(joueur => joueur.ChampsPropresAPoona.Sexe == sexe);

            return result;
        }

        public string GenererMailingList(string seperateur)
        {
            var sb = new StringBuilder();
            bool first = true;
            foreach (var joueur in ObtenirJoueursQuiCorrespondentAuxFiltres())
            {
                if (first)
                    first = false;
                else
                    sb.Append(seperateur);

                if (joueur.Mail != null && joueur.Mail.Length > 0)
                    sb.Append(joueur.Mail);
                else 
                    sb.Append(joueur.ChampsPropresAPoona.Mail);

            }

            return sb.ToString();
        }
    }
}
