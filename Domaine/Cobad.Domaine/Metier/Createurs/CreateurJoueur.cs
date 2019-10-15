using Cobad.Domaine.Metier.Exceptions;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Createurs
{
    public class CreateurJoueur : ICreateurJoueur
    {
        private int license = -1;
        private Joueur.ChampsPoona champsPoona = new Joueur.ChampsPoona();

        private IRepertoireJoueurs repertoireJoueurs;
        internal CreateurJoueur(IRepertoireJoueurs repertoireJoueurs)
        {
            this.repertoireJoueurs = repertoireJoueurs;
        }
        public CreateurJoueur DontLaLicenceEst(int license)
        {
            this.license = license;
            return this;
        }
        public CreateurJoueur DontLesChampsPoonaSont(Joueur.ChampsPoona champsPoona)
        {
            this.champsPoona = champsPoona;
            return this;
        }

        public Joueur Creer()
        {
            if (license == -1)
                throw new ArgumentNullException("Il faut specifier au moins la license du joueur");
            else if (repertoireJoueurs.Existe(license))
                throw new DuplicationException();

            var joueur = new Joueur(license, champsPoona);
            repertoireJoueurs.MettreAJour(joueur);
            return joueur;
        }

    }
}
