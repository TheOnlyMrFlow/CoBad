using System;
using System.Collections.Generic;

namespace Cobad.Domaine
{
    public class Competition
    {
        public string Nom { get; set; } = "";
        public DateTime Date { get; set; }

        public IEnumerable<Tableau> Tableaux;

    }
}