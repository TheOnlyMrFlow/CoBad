using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier
{
    class CategorieInconnueException : Exception
    {
        public CategorieInconnueException() : base("Cette categorie n'existe pas.") { }
    }
}
