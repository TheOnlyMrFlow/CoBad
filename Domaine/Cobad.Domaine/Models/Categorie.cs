using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine
{

    public enum Categorie
    { 
        MiniBad,    
        Poussin1,
        Poussin2,
        Benjamin1,
        Benjamin2,
        Minime1,
        Minime2,
        Cadet1,
        Cadet2,
        Junior1,
        Junior2 ,
        Senior1,
        Senior2,
        Veteran1,
        Veteran2,
        Veteran3,
        Veteran4,
        Veteran5,
        Veteran6,
        Veteran7,
        Aucune
    }

    //// ;'equivalent d'une enum mais avec des methodes 
    //public sealed class Categorie
    //{


    //    public static readonly Categorie MiniBad = new Categorie("MiniBad");
    //    public static readonly Categorie Poussin1 = new Categorie("Poussin 1");
    //    public static readonly Categorie Poussin2 = new Categorie("Poussin 1");
    //    public static readonly Categorie Benjamin1 = new Categorie("Benjamin  1");
    //    public static readonly Categorie Benjamin2 = new Categorie("Benjamin 2");
    //    public static readonly Categorie Minime1 = new Categorie("Minime 1");
    //    public static readonly Categorie Minime2 = new Categorie("Minime 2");
    //    public static readonly Categorie Cadet1 = new Categorie("Cadet 1");
    //    public static readonly Categorie Cadet2 = new Categorie("Cadet 2");
    //    public static readonly Categorie Junior1 = new Categorie("Junior 1");
    //    public static readonly Categorie Junior2 = new Categorie("Junior 2");
    //    public static readonly Categorie Senior1 = new Categorie("Sénior 1");
    //    public static readonly Categorie Senior2 = new Categorie("Sénior 2");
    //    public static readonly Categorie Veteran1 = new Categorie("Vétéran 1");
    //    public static readonly Categorie Veteran2 = new Categorie("Vétéran 2");
    //    public static readonly Categorie Veteran3 = new Categorie("Vétéran 3");
    //    public static readonly Categorie Veteran4 = new Categorie("Vétéran 4");
    //    public static readonly Categorie Veteran5 = new Categorie("Vétéran 5");
    //    public static readonly Categorie Veteran6 = new Categorie("Vétéran 6");
    //    public static readonly Categorie Veteran7 = new Categorie("Vétéran 7");

    //    private static readonly Dictionary<string, Categorie> StringToCategorie = new Dictionary<string, Categorie>
    //    {
    //        {  MiniBad.nom, MiniBad },
    //        {  Poussin1.nom, Poussin1 },
    //        {  Poussin2.nom, Poussin2 },
    //        {  Benjamin1.nom, Benjamin1 },
    //        {  Benjamin2.nom, Benjamin2 },
    //        {  Minime1.nom, Minime1 },
    //        {  Minime2.nom, Minime2 },
    //        {  Cadet1.nom, Cadet1 },
    //        {  Cadet2.nom, Cadet2 },
    //        {  Junior1.nom, Junior1 },
    //        {  Junior2.nom, Junior2 },
    //        {  Senior1.nom, Senior1 },
    //        {  Senior2.nom, Senior2 },
    //        {  Veteran1.nom, Veteran1 },
    //        {  Veteran2.nom, Veteran2 },
    //        {  Veteran3.nom, Veteran3 },
    //        {  Veteran4.nom, Veteran4 },
    //        {  Veteran5.nom, Veteran5 },
    //        {  Veteran6.nom, Veteran6 },
    //        {  Veteran7.nom, Veteran7 }
    //    };

    //    private readonly string nom;

    //    public override string ToString()
    //    {
    //        return nom;
    //    }

    //    public static Categorie FromString(string nomCategorie)
    //    {
    //        Categorie categorie;
    //        if (StringToCategorie.TryGetValue(nomCategorie, out categorie))
    //            return categorie;
    //        else
    //            throw new CategorieInconnueException();
    //    }
    //    private Categorie(string nom)
    //    {
    //        this.nom = nom;
    //    }
    //}
}
    
