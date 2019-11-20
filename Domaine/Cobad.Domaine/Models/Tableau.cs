using System.Collections.Generic;

namespace Cobad.Domaine
{
    public class Tableau
    {
        public string Nom { get; set; }
        public IEnumerable<Round> Rounds { get; set; }
        public int Id { get; set; }
        public string Categorie { get; set; }
        public string Niveau { get; set; }
    }
}