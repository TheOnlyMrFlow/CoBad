using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine
{

    public enum Plume
    {
        Blanche,
        Jaune,
        Verte,
        Bleue,
        Rouge
    }

    //// ;'equivalent d'une enum mais avec des methodes 
    //public sealed class Plume
    //{
    //    public static readonly Plume PlumeBlanche = new Plume("Plume Blanche");
    //    public static readonly Plume PlumeJaune = new Plume("Plume Jaune");
    //    public static readonly Plume PlumeVerte = new Plume("Plume Verte");
    //    public static readonly Plume PlumeBleue = new Plume("Plume Bleue");
    //    public static readonly Plume PlumeRouge = new Plume("plume Rouge");

    //    private readonly string nom;

    //    public override string ToString()
    //    {
    //        return nom;
    //    }

    //    public static Plume FromString(string nomPlume)
    //    {
    //        if (nomPlume.ToLower().Contains("blanc"))
    //            return PlumeBlanche;
    //        else if (nomPlume.ToLower().Contains("jaune"))
    //            return PlumeJaune;
    //        else if (nomPlume.ToLower().Contains("vert"))
    //            return PlumeVerte;
    //        else if (nomPlume.ToLower().Contains("bleu"))
    //            return PlumeBleue;
    //        else if (nomPlume.ToLower().Contains("rouge"))
    //            return PlumeRouge;
    //        else
    //            throw new PlumeInconnueException();
    //    }
    //    private Plume(string nom)
    //    {
    //        this.nom = nom;
    //    }
    //}
}

