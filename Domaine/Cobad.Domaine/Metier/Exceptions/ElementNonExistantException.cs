using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Exceptions
{
    public class ElementNonExistantException : Exception
    {
        public ElementNonExistantException() : base("Cet element n'existe pas") { }
    }
}
