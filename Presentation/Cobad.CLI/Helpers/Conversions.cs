using Cobad.CLI.Exceptions;
using Cobad.Domaine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.CLI.Helpers
{
    internal static class Conversions
    {
        public static Categorie StringVersCategorie(string categorieAsString)
        {
            categorieAsString = categorieAsString.Trim().ToLower().Replace(" ", "").Replace("é", "e");
            switch (categorieAsString)
            {
                case "minibad":
                    return Categorie.MiniBad;
                case "poussin1":
                    return Categorie.Poussin1;
                case "poussin2":
                    return Categorie.Poussin1;
                case "benjamin1":
                    return Categorie.Benjamin1;
                case "benjamin2":
                    return Categorie.Benjamin2;
                case "minime1":
                    return Categorie.Minime1;
                case "minime2":
                    return Categorie.Minime2;
                case "cadet1":
                    return Categorie.Cadet1;
                case "cadet2":
                    return Categorie.Cadet2;
                case "junior1":
                    return Categorie.Junior1;
                case "junior2":
                    return Categorie.Junior2;
                case "senior1":
                    return Categorie.Senior1;
                case "senior2":
                    return Categorie.Senior2;
                case "veteran1":
                    return Categorie.Veteran1;
                case "veteran2":
                    return Categorie.Veteran2;
                case "veteran3":
                    return Categorie.Veteran3;
                case "veteran4":
                    return Categorie.Veteran4;
                case "veteran5":
                    return Categorie.Veteran5;
                case "veteran6":
                    return Categorie.Veteran6;
                case "veteran7":
                    return Categorie.Veteran7;
                case "aucune":
                    return Categorie.Aucune;
                default:
                    throw new ParametreIncorrecteException("Categorie inexistante");
            }
        }
    }
}
