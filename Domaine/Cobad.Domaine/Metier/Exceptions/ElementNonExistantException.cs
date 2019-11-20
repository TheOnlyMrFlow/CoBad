using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier
{
    public class ElementNonExistantException : Exception
    {
        public ElementNonExistantException() : base("Cet element n'existe pas") { }
    }
}
