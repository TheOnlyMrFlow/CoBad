using System;
using System.Collections.Generic;

namespace Cobad.Domaine
{
    public class Club
    {

        public Club(ChampsPoona champsPoona)
        {
            this.champsPropresAPoona = champsPoona;
            this.champsPropresACobad = new ChampsCobad();
        }

        public Club(ChampsPoona champsPoona, ChampsCobad champsCobad)
        {
            this.champsPropresAPoona = champsPoona;
            this.champsPropresACobad = champsCobad;
        }

        public class ChampsPoona
        {
            public ChampsPoona(string numero)
            {
                this.Numero = numero;
            }

            public ChampsPoona(string numero, Adresse adresse, string nom, string sigle, string ville, string codePostal, string nomPresident, bool isCorpo, string tel, string mobile, string mail, string siteWeb)
            {
                Adresse = adresse;
                Nom = nom;
                Sigle = sigle;
                Ville = ville;
                CodePostal = codePostal;
                NomPresident = nomPresident;
                Numero = numero;
                IsCorpo = isCorpo;
                Tel = tel;
                Mobile = mobile;
                Mail = mail;
                SiteWeb = siteWeb;
            }

            public Adresse Adresse { get; set; } = new Adresse();
            public string Nom { get; set; } = "";
            public string Sigle { get; set; } = "";
            public string Ville { get; set; } = "";
            public string CodePostal { get; set; } = "";
            public string NomPresident { get; set; } = "";
            public string Numero { get; set; } = "";
            public bool IsCorpo { get; set; } = false;
            public string Tel { get; set; } = "";
            public string Mobile { get; set; } = "";
            public string Mail { get; set; } = "";
            public string SiteWeb { get; set; } = "";
        }

        public class ChampsCobad
        {
            public List<Personnel> Personnel { get; set; } = new List<Personnel>();

        }

        public ChampsPoona champsPropresAPoona;
        public ChampsCobad champsPropresACobad;

    }
}
