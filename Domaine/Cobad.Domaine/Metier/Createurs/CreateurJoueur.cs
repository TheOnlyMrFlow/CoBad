using Cobad.Domaine.Metier;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Createurs
{
    class CreateurJoueur : ICreateurJoueur
    {
        private int license = -1;
        private string numeroClub;
        private Joueur.ChampsPoona champsPoona = new Joueur.ChampsPoona();

        private IRepertoireJoueurs repertoireJoueurs;
        private IRepertoireClubs repertoireClubs;
        internal CreateurJoueur(IRepertoireJoueurs repertoireJoueurs, IRepertoireClubs repertoireClubs)
        {
            this.repertoireJoueurs = repertoireJoueurs;
            this.repertoireClubs = repertoireClubs;
        }
        public ICreateurJoueur DontLaLicenceEst(int license)
        {
            this.license = license;
            return this;
        }

        public ICreateurJoueur DontLeClubPorteLeNumero(string numeroClub)
        {
            this.numeroClub = numeroClub;
            return this;
        }

        public ICreateurJoueur DontLesChampsPoonaSont(Joueur.ChampsPoona champsPoona)
        {
            this.champsPoona = champsPoona;
            return this;
        }

        public Joueur Creer()
        {
            if (license == -1)
                throw new ArgumentNullException("Il faut specifier la license du joueur");
            if (numeroClub == null)
                throw new ArgumentNullException("Il faut specifier le club auquel appartient le joueur");
            else if (! repertoireClubs.Existe(numeroClub))
                throw new ElementNonExistantException();
            else if (repertoireJoueurs.Existe(license))
                throw new DuplicationException();

            var joueur = new Joueur(license, numeroClub, champsPoona);
            repertoireJoueurs.Ajouter(joueur);
            return joueur;
        }
    }
}
