using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Createurs
{
    public class CreateurJoueur : ICreateurJoueur
    {
        internal CreateurJoueur() { }

        public CreateurJoueur DontLesChampsPoonaSont(Joueur.ChampsPoona champsPoona)
        {
            throw new NotImplementedException();
        }

        public Joueur Creer()
        {
            throw new NotImplementedException();
        }
    }
}
