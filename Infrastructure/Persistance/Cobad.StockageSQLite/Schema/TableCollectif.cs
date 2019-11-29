using Cobad.Domaine;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cobad.StockageSQLite.Schema
{
    [Table("Collectif")]
    internal class TableCollectif
    {
        public TableCollectif() { }

        public TableCollectif(Collectif collectif)
        {
            this.Nom = collectif.Nom;

            Joueurs = collectif.Membres.Select(j => new TableJoueur(j)).ToList();

            var categoriesAsString = collectif.Categories.Select(c => Joueur.CategorieToString[c]);

            Categories = String.Join<string>(',', categoriesAsString);
        }

        public TableCollectif(string nom)
        {
            this.Nom = nom;
        }

        public Collectif VersModeleCollectif()
        {

            var collectif = new Collectif(this.Nom);

            var Categories =
                    this.Categories
                    .Split(',')
                    .Select(c => Joueur.StringToCategorie[c]);

            collectif.Categories.UnionWith(Categories);
            collectif.Membres.AddRange(
                Joueurs.Select(j => j.VersModeleJoueur())
                );

            return collectif;
        
        }

        [PrimaryKey, Unique, NotNull]
        public string Nom { get; set; }

        public string Categories { get; set; }

        [ManyToMany(typeof(TableJonctionJoueurCollectif))]
        public List<TableJoueur> Joueurs { get; set; }
    }
}
