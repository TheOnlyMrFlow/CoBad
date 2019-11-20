using System.Collections.Generic;

namespace Cobad.Domaine
{
    public class Match
    {
        public int Id { get; set; }

        public Joueur[] EquipeA;
        public Joueur[] EquipeB;

        public int[] ScoresA;
        public int[] ScoresB;

        public bool Abandon;

        public bool Forfait;

    }

    
}