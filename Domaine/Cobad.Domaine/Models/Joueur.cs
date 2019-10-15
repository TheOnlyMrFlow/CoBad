using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.Domaine
{
    public class Joueur
    {
        public Joueur(int license)
        {
            this.Licence = license;
            ChampsPropresAPoona = new ChampsPoona();
        }
        public Joueur(int license, ChampsPoona champsPropresAPoona)
        {
            this.Licence = license;
            ChampsPropresAPoona = champsPropresAPoona;
        }

        public class ChampsPoona
        {
            public ChampsPoona() { }

            public ChampsPoona(string nom, string prenom, int ageFinSaison, char sexe, string ville, string tel, string mail, string numeroClub, string sigleClub, Categorie categorie, string hebdoSimpleClassement, float hebdoSimpleCPPH, string hebdoDoubleClassement, float hebdoDoubleCPPH, string hebdoMixteClassement, string hebdoMixteCPPH, bool competiteurActif, bool mute, bool unss, bool fnsu, Plume meilleurPlume)
            {
                Nom = nom;
                Prenom = prenom;
                AgeFinSaison = ageFinSaison;
                Sexe = sexe;
                Ville = ville;
                Tel = tel;
                Mail = mail;
                NumeroClub = numeroClub;
                SigleClub = sigleClub;
                Categorie = categorie;
                HebdoSimpleClassement = hebdoSimpleClassement;
                HebdoSimpleCPPH = hebdoSimpleCPPH;
                HebdoDoubleClassement = hebdoDoubleClassement;
                HebdoDoubleCPPH = hebdoDoubleCPPH;
                HebdoMixteClassement = hebdoMixteClassement;
                HebdoMixteCPPH = hebdoMixteCPPH;
                CompetiteurActif = competiteurActif;
                Mute = mute;
                Unss = unss;
                Fnsu = fnsu;
                MeilleurPlume = meilleurPlume;
            }
            public string Nom { get; set; } = "";
            public string Prenom { get; set; } = "";
            public int AgeFinSaison { get; set; } = 0;
            public char Sexe { get; set; } = 'm';
            public string Ville { get; set; } = "";
            public string Tel { get; set; } = "";
            public string Mail { get; set; } = "";
            public string NumeroClub { get; set; } = "";
            public string SigleClub { get; set; } = "";
            public Categorie Categorie { get; set; }
            public string HebdoSimpleClassement { get; set; } = "";
            public float HebdoSimpleCPPH { get; set; }
            public string HebdoDoubleClassement { get; set; } = "";
            public float HebdoDoubleCPPH { get; set; }
            public string HebdoMixteClassement { get; set; } = "";
            public string HebdoMixteCPPH { get; set; } = "";
            public bool CompetiteurActif { get; set; }
            public bool Mute { get; set; } = false;
            public bool Unss { get; set; } = false;
            public bool Fnsu { get; set; } = false;
            public Plume MeilleurPlume { get; set; }
        }

        public int Licence { get; set; }
        public ChampsPoona ChampsPropresAPoona { get; set; }

        public string Tel { get; set; }

        public string Mail { get; set; }

    }
}
