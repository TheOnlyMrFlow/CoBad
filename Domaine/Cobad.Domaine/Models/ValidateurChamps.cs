using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Cobad.Domaine
{
    class ValidateurChamps
    {
        public static void ImposerNumeroTelValide(string numero)
        {
            if (numero == null || numero == "")
                return;

            numero = numero.Replace(" ", "");
            if (!Regex.IsMatch(numero, @"^(?:(?:\+|00)33|0)\s*[1-9](?:[\s.-]*\d{2}){4}$"))
                throw new NumeroTelInvalideException();
        }

        public static void ImposerMailValide(string mail)
        {
            try
            {
                MailAddress m = new MailAddress(mail);

            }
            catch (FormatException)
            {
                throw new MailInvalideException();
            }
        }

        public static void ImposerLongueurMaximal(string champ, int longueurMax)
        {
            if (champ.Length > longueurMax)
                throw new ChampsTropLongException(longueurMax);
        }

        public static void ImposerLongueurMinimal(string champ, int longueurMin)
        {
            if (champ.Length < longueurMin)
                throw new ChampsTropCourtException(longueurMin);
        }

        public static void ImposerChampsNonNull(Object champ)
        {
            if (champ == null)
                throw new ChampsNullException();
        }

        
    }
}
