using Cobad.Domaine.PortsSecondaires;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Modificateurs
{
    internal class ModificateurCollectif : IModificateurCollectif
    {
        internal ModificateurCollectif() { }

        public IModificateurCollectif AjouterCategorieCible(Categorie categorie)
        {
            throw new NotImplementedException();
        }

        public IModificateurCollectif AjouterMembre(int licenseDuMembre)
        {
            throw new NotImplementedException();
        }

        public IModificateurCollectif AjouterMembre(Joueur membre)
        {
            throw new NotImplementedException();
        }

        public IModificateurCollectif RetirerCategorieCible(Categorie categorie)
        {
            throw new NotImplementedException();
        }

        public IModificateurCollectif RetirerMembre(int licenseDuMembre)
        {
            throw new NotImplementedException();
        }

        public IModificateurCollectif RetirerMembre(Joueur membre)
        {
            throw new NotImplementedException();
        }

        public Collectif Sauvegarder()
        {
            throw new NotImplementedException();
        }

        public Collectif SauvegarderOuCreerSiExistePas()
        {
            throw new NotImplementedException();
        }

        public IModificateurCollectif SetNom()
        {
            throw new NotImplementedException();
        }
    }
}
