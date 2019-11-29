using Cobad.Domaine;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageSQLite.Schema
{
    [Table("Joueur")]
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
            Sexe = "" + joueur.ChampsPropresAPoona.Sexe;
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

        public Joueur VersModeleJoueur()
        {
            var joueur =
                new Joueur(
                    this.License,
                    this.NumeroClub,
                    new Joueur.ChampsPoona(
                        this.Nom,
                        this.Prenom,
                        this.Age,
                        this.Sexe[0],
                        this.Ville,
                        this.Tel,
                        this.Mail,
                        Joueur.StringToCategorie[this.Categorie],
                        this.HebdoSimpleClassement,
                        this.HebdoSimpleCPPH,
                        this.HebdoDoubleClassement,
                        this.HebdoDoubleCPPH,
                        this.HebdoMixteClassement,
                        this.HebdoMixteCPPH,
                        this.CompetiteurActif,
                        this.Mute,
                        this.Unss,
                        this.Fnsu,
                        Joueur.StringToPlume[this.MeilleurPlume]
                        )
                    );

            joueur.Mail = this.CoBad_Mail;
            joueur.Tel = this.CoBad_Tel;

            return joueur;
        }

        [PrimaryKey, NotNull, Unique]
        public int License { get; set; }
        
        public string NumeroClub { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public int Age { get; set; }

        public string Sexe { get; set; }

        public string Ville { get; set; }

        public string Tel { get; set; }

        public string CoBad_Tel { get; set; } = "";

        public string Mail { get; set; }

        public string CoBad_Mail { get; set; } = "";

        public string Categorie { get; set; }

        public string HebdoSimpleClassement { get; set; }

        public float HebdoSimpleCPPH { get; set; }

        public string HebdoDoubleClassement { get; set; }

        public float HebdoDoubleCPPH { get; set; }

        public string HebdoMixteClassement { get; set; }

        public float HebdoMixteCPPH { get; set; }

        public bool CompetiteurActif { get; set; }

        public bool Mute { get; set; }

        public bool Unss { get; set; }

        public bool Fnsu { get; set; }

        public string MeilleurPlume { get; set; }

        [ManyToMany(typeof(TableJonctionJoueurCollectif))]
        public List<TableCollectif> Collectifs { get; set; }
    }
}



