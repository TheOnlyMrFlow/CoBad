using System.Collections.Generic;

namespace Cobad.Domaine
{
    public class Match
    {
        public int Id { get; set; }

        public Joueur[] EquipeA;
        public Joueur[] EquipeB;

        public Set[] Sets;

        public bool Abandon;

        public bool Forfait;

        public bool EstUnMatchSimple { get => EquipeA.Length == 1;  }

        public bool EstUnMatchDouble { get => EquipeA.Length == 2; }

    }

    
}