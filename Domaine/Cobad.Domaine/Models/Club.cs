using System;
using System.Collections.Generic;

namespace Cobad.Domaine
{
    public class Club
    {
        public Club(string numero)
        {
            this.Numero = numero;
            this.champsPropresAPoona = new ChampsPoona();
        }
        public Club(string numero, ChampsPoona champsPoona)
        {
            this.Numero = numero;
            this.champsPropresAPoona = champsPoona;
        }

        public Club(string numero, ChampsPoona champsPoona, List<Personnel> personnel) : this(numero, champsPoona)
        {
            this.Personnel = personnel;
        }

        public class ChampsPoona
        {
            public ChampsPoona() { }
            public ChampsPoona(Adresse adresse, string nom, string sigle, string ville, string codePostal, string nomPresident, bool isCorpo, string tel, string mobile, string mail, string siteWeb)
            {
                Adresse = adresse;
                Nom = nom;
                Sigle = sigle;
                Ville = ville;
                CodePostal = codePostal;
                NomPresident = nomPresident;
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
            public bool IsCorpo { get; set; } = false;
            public string Tel { get; set; } = "";
            public string Mobile { get; set; } = "";
            public string Mail { get; set; } = "";
            public string SiteWeb { get; set; } = "";
        }


        public string Numero;

        public ChampsPoona champsPropresAPoona;
        public List<Personnel> Personnel { get; set; } = new List<Personnel>();

    }
}
