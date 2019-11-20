using Cobad.Domaine.Metier;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Createurs
{
    class CreateurCollectif : ICreateurCollectif
    {

        private IRepertoireCollectifs repertoireCollectifs;

        string nom;

        ISet<Categorie> categories = new HashSet<Categorie>();
        List<Joueur> membres = new List<Joueur>();

        public CreateurCollectif(IRepertoireCollectifs repertoireCollectifs)
        {
            this.repertoireCollectifs = repertoireCollectifs;
        }

        public ICreateurCollectif DontLeNomEst(string nom)
        {
            this.nom = nom;
            return this;
        }
        public ICreateurCollectif DontLesCategoriesSont(IEnumerable<Categorie> categories)
        {
            this.categories = new HashSet<Categorie>(categories);
            return this;
        }

        public ICreateurCollectif DontLesMembresSont(IEnumerable<Joueur> membres)
        {
            foreach (var m in membres)
                this.membres.Add(m);
            return this;
        }

        public Collectif Creer()
        {
            if (nom == null)
                throw new ArgumentNullException("Il faut specifier le nom du collectif");
            else if (repertoireCollectifs.Existe(nom))
                throw new DuplicationException();

            var collectif = new Collectif(nom);
            collectif.Categories.UnionWith(categories);
            collectif.Membres = membres;
            repertoireCollectifs.Ajouter(collectif);
            return collectif;
        }

    }
}
