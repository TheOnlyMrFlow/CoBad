using System.Collections.Generic;

namespace Cobad.Domaine
{
    public class Round
    {
        public string Nom { get; set; }
        public IEnumerable<Match> Matchs { get; set; }
        public int Id { get; set; }
    }
}