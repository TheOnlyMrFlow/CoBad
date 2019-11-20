using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier
{
    public class ChampsIncorrectException : Exception
    {
        public ChampsIncorrectException(string message) : base(message) { }
    }

    public class ChampsNullException : ChampsIncorrectException
    {
        public ChampsNullException() : base("Ce champs ne peut pas etre null.") { }
    }

    public class ChampsTropCourtException : ChampsIncorrectException
    {
        public ChampsTropCourtException(int longueurMin) : base("Ce champs doit contenir au moins " + longueurMin + " caractere(s).") { }
    }

    public class ChampsTropLongException : ChampsIncorrectException
    {
        public ChampsTropLongException(int longueurMax) : base("Ce champs doit contenir au plus " + longueurMax + " caracteres.") { }
    }

    public class NumeroTelInvalideException : ChampsIncorrectException
    {
        public NumeroTelInvalideException() : base("Ce numero n'est pas un numero francais valide.") { }
    }
    public class MailInvalideException : ChampsIncorrectException
    {
        public MailInvalideException() : base("Cet adresse mail n'est pas valide.") { }
    }



}
