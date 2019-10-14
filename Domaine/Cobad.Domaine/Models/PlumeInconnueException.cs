using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine
{
    class PlumeInconnueException : Exception
    {
        public PlumeInconnueException() : base("Cette plume est inconnue.") { }
    }
}
