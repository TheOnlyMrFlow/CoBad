using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Exceptions
{
    public class DuplicationException : Exception
    {
        public DuplicationException() : base("Cet element existe deja") { }
    }
}
