using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.CLI.Exceptions
{
    internal class CLIExcepetion : Exception
    {
        public CLIExcepetion(string msg) : base(msg) { }
    }

    internal class ParametreIncorrecteException : CLIExcepetion
    {
        public ParametreIncorrecteException(string msg) : base(msg) { }
    }

}
