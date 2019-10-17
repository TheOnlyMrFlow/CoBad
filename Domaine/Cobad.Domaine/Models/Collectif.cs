using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine
{
    public class Collectif
    {
        public Collectif(string nom)
        {
            Nom = nom;
            Categories = new HashSet<Categorie>();
            Membres = new List<Joueur>();
        }

        private string _nom;
        public string Nom
        {
            get => _nom;
            set
            {
                ValidateurChamps.ImposerChampsNonNull(value);
                ValidateurChamps.ImposerLongueurMaximal(value, 50);
                _nom = value;
            }
        }

        public ISet<Categorie> Categories { get; internal set; }

        public List<Joueur> Membres { get; internal set; }
    }
}
