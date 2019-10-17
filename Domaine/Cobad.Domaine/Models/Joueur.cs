using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.Domaine
{
    public class Joueur
    {

        public static readonly Dictionary<string, Categorie> StringToCategorie = new Dictionary<string, Categorie>
        {
            { "Minibad", Categorie.MiniBad},
            { "Poussin 1", Categorie.Poussin1},
            { "Poussin 2", Categorie.Poussin2},
            { "Benjamin 1", Categorie.Benjamin1},
            { "Benjamin 2", Categorie.Benjamin2},
            { "Minime 1", Categorie.Minime1},
            { "Minime 2", Categorie.Minime2},
            { "Cadet 1", Categorie.Cadet1},
            { "Cadet 2", Categorie.Cadet2},
            { "Junior 1", Categorie.Junior1},
            { "Junior 2", Categorie.Junior2},
            { "Sénior 1", Categorie.Senior1},
            { "Sénior 2", Categorie.Senior2},
            { "Vétéran 1", Categorie.Veteran1},
            { "Vétéran 2", Categorie.Veteran2},
            { "Vétéran 3", Categorie.Veteran3},
            { "Vétéran 4", Categorie.Veteran4},
            { "Vétéran 5", Categorie.Veteran5},
            { "Vétéran 6", Categorie.Veteran6},
            { "Vétéran 7", Categorie.Veteran7},
            { "", Categorie.Aucune}
        };

        public static readonly Dictionary<Categorie, string> CategorieToString = StringToCategorie.ToDictionary((i) => i.Value, (i) => i.Key);


        public static readonly Dictionary<string, Plume> StringToPlume = new Dictionary<string, Plume>
        {
            { "Blanche", Plume.Blanche},
            { "Jaune", Plume.Jaune},
            { "Verte", Plume.Verte},
            { "Bleue", Plume.Bleue},
            { "Rouge", Plume.Rouge},
            { "", Plume.Aucune}
        };

        public static readonly Dictionary<Plume, string> PlumeToString = StringToPlume.ToDictionary((i) => i.Value, (i) => i.Key);
        public Joueur(int license, string numeroClub)
        {
            this.Licence = license;
            this.NumeroClub = numeroClub;
            ChampsPropresAPoona = new ChampsPoona();
        }
        public Joueur(int license, string numeroClub, ChampsPoona champsPropresAPoona)
        {
            this.Licence = license;
            this.NumeroClub = numeroClub;
            ChampsPropresAPoona = champsPropresAPoona;
        }

        public class ChampsPoona
        {
            public ChampsPoona() { }

            public ChampsPoona(string nom, string prenom, int ageFinSaison, char sexe, string ville, string tel, string mail, Categorie categorie, string hebdoSimpleClassement, float hebdoSimpleCPPH, string hebdoDoubleClassement, float hebdoDoubleCPPH, string hebdoMixteClassement, float hebdoMixteCPPH, bool competiteurActif, bool mute, bool unss, bool fnsu, Plume meilleurPlume)
            {
                Nom = nom;
                Prenom = prenom;
                AgeFinSaison = ageFinSaison;
                Sexe = sexe;
                Ville = ville;
                Tel = tel;
                Mail = mail;
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
            public Categorie Categorie { get; set; }
            public string HebdoSimpleClassement { get; set; } = "";
            public float HebdoSimpleCPPH { get; set; }
            public string HebdoDoubleClassement { get; set; } = "";
            public float HebdoDoubleCPPH { get; set; }
            public string HebdoMixteClassement { get; set; } = "";
            public float HebdoMixteCPPH { get; set; }
            public bool CompetiteurActif { get; set; }
            public bool Mute { get; set; } = false;
            public bool Unss { get; set; } = false;
            public bool Fnsu { get; set; } = false;
            public Plume MeilleurPlume { get; set; }
        }

        public int Licence { get; set; }

        public string NumeroClub { get; set; }
        public ChampsPoona ChampsPropresAPoona { get; set; }

        public string Tel { get; set; } = "";

        public string Mail { get; set; } = "";

    }
}
