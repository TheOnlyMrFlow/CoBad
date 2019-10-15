using Cobad.Domaine;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL.DBSchema
{
    [Table(Name = "joueur")]
    internal class TableJoueur
    {

        public TableJoueur() { }

        public TableJoueur(Joueur joueur)
        {
            License = joueur.Licence;
            NumeroClub = joueur.NumeroClub;
            Nom = joueur.ChampsPropresAPoona.Nom;
            Prenom = joueur.ChampsPropresAPoona.Prenom;
            Age = joueur.ChampsPropresAPoona.AgeFinSaison;
            Sexe = joueur.ChampsPropresAPoona.Sexe;
            Ville = joueur.ChampsPropresAPoona.Ville;
            Tel = joueur.ChampsPropresAPoona.Tel;
            CoBad_Tel = joueur.Tel;
            Mail = joueur.ChampsPropresAPoona.Mail;
            CoBad_Mail = joueur.Mail;
            Categorie = Joueur.CategorieToString[joueur.ChampsPropresAPoona.Categorie];
            HebdoSimpleClassement = joueur.ChampsPropresAPoona.HebdoSimpleClassement;
            HebdoSimpleCPPH = joueur.ChampsPropresAPoona.HebdoSimpleCPPH;
            HebdoDoubleClassement = joueur.ChampsPropresAPoona.HebdoDoubleClassement;
            HebdoDoubleCPPH = joueur.ChampsPropresAPoona.HebdoDoubleCPPH;
            HebdoMixteClassement = joueur.ChampsPropresAPoona.HebdoMixteClassement;
            HebdoMixteCPPH = joueur.ChampsPropresAPoona.HebdoMixteCPPH;
            CompetiteurActif = joueur.ChampsPropresAPoona.CompetiteurActif;
            Mute = joueur.ChampsPropresAPoona.Mute;
            Unss = joueur.ChampsPropresAPoona.Unss;
            Fnsu = joueur.ChampsPropresAPoona.Fnsu;
            MeilleurPlume = Joueur.PlumeToString[joueur.ChampsPropresAPoona.MeilleurPlume];
        }

        [Column(Name = "License"), PrimaryKey]
        public int License { get; set; }

        [Column(Name = "NumeroClub")]
        public string NumeroClub { get; set; }

        [Column(Name = "Nom")]
        public string Nom { get; set; }

        [Column(Name = "Prenom")]
        public string Prenom { get; set; }

        [Column(Name = "Age")]
        public int Age { get; set; }

        [Column(Name = "Sexe")]
        public char Sexe { get; set; }

        [Column(Name = "Ville")]
        public string Ville { get; set; }

        [Column(Name = "Tel")]
        public string Tel { get; set; }

        [Column(Name = "Cobad-Tel")]
        public string CoBad_Tel { get; set; } = "";

        [Column(Name = "Mail")]
        public string Mail { get; set; }

        [Column(Name = "Cobad-Mail")]
        public string CoBad_Mail { get; set; } = "";

        [Column(Name = "Categorie")]
        public string Categorie { get; set; }

        [Column(Name = "HebdoSimpleClassement")]
        public string HebdoSimpleClassement { get; set; }

        [Column(Name = "HebdoSimpleCPPH")]
        public float HebdoSimpleCPPH { get; set; }

        [Column(Name = "HebdoDoubleClassement")]
        public string HebdoDoubleClassement { get; set; }

        [Column(Name = "HebdoDoubleCPPH")]
        public float HebdoDoubleCPPH { get; set; }

        [Column(Name = "HebdoMixteClassement")]
        public string HebdoMixteClassement { get; set; }

        [Column(Name = "HebdoMixteCPPH")]
        public float HebdoMixteCPPH { get; set; }

        [Column(Name = "CompetiteurActif")]
        public bool CompetiteurActif { get; set; }

        [Column(Name = "Mute")]
        public bool Mute { get; set; }

        [Column(Name = "Unss")]
        public bool Unss { get; set; }

        [Column(Name = "Fnsu")]
        public bool Fnsu { get; set; }

        [Column(Name = "MeilleurPlume")]
        public string MeilleurPlume { get; set; }
    }
}
