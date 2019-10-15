using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.AccesPoona;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AccesseurPoonaCSV
{
    public class AccesseurPoonaParFichierCSV : IAccesseurPoona
    {

        private string fichierClubs;
        private string fichierJoueurs;

        public void FixerLeFichierDesJoueurs(string nomDuFichier)
        {
            fichierJoueurs = nomDuFichier;
        }

        public void FixerLeFichierDesClubs(string nomDuFichier)
        {
            fichierClubs = nomDuFichier;
        }

        public IEnumerable<Club> ObtenirTousLesClubsDeLaBasePoona()
        {

            using (var reader = new StreamReader(fichierClubs, Encoding.UTF8))
            {

                List<Club> clubs = new List<Club>();

                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    var Nom = values[0];
                    var Sigle = values[1];
                    var Ville = values[2];
                    var CodePostal = values[3];
                    var Adresse = new Adresse();
                    Adresse.PointRemise = values[4];
                    Adresse.Localisation = values[5];
                    Adresse.NumeroEtRue = values[6];
                    Adresse.Distribution = values[7];
                    Adresse.CodePostal = values[8];
                    Adresse.Ville = values[9];
                    Adresse.Cedex = values[10];
                    Adresse.Pays = values[11];
                    var NomPresident = values[12];
                    var Numero = values[13];
                    var IsCorpo = values[14].Equals("1") ? true : false;
                    var Tel = values[15];
                    var Mobile = values[16];
                    var Mail = values[17];
                    var SiteWeb = values[18];

                    var champsPoona = new Club.ChampsPoona(Adresse, Nom, Sigle, Ville, CodePostal, NomPresident, IsCorpo, Tel, Mobile, Mail, SiteWeb);
                    var club = new Club(Numero, champsPoona);

                    clubs.Add(club);

                }

                return clubs;
            }
        }

        public IEnumerable<Joueur> ObtenirTousLesJoueursDeLaBasePoona()
        {
            using (var reader = new StreamReader(fichierJoueurs, Encoding.UTF8))
            {

                List<Joueur> joueurs = new List<Joueur>();

                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    var Sexe = values[0][0];
                    var Nom = values[1];
                    var Prenom = values[2];
                    var Licence = int.Parse(values[3]);
                    var AgeFinSaison = values[4];
                    var Ville = values[5];
                    var Mail = values[6];
                    var Tel = values[7];
                    var NumeroClub = values[8];
                    var Categorie = values[10];
                    var HebdoSimpleClassement = values[11];
                    var HebdoSimpleCPPH = values[12];
                    var HebdoDoubleClassement = values[13];
                    var HebdoDoubleCPPH = values[14];
                    var HebdoMixteClassement = values[15];
                    var HebdoMixteCPPH = values[16];
                    var CompetiteurActif = values[17];
                    var Mute = values[18];
                    var Unss = values[19];
                    var Fnsu = values[20];
                    var MeilleurPlume = values[21];

                    var champsPoona = new Joueur.ChampsPoona(
                        Nom,
                        Prenom,
                        StringVersInt(AgeFinSaison),
                        Sexe,
                        Ville,
                        Tel,
                        Mail,
                        StringVersCategorie(Categorie),
                        HebdoSimpleClassement,
                        StringVersFloat(HebdoSimpleCPPH), 
                        HebdoDoubleClassement,
                        StringVersFloat(HebdoDoubleCPPH),
                        HebdoMixteClassement,
                        StringVersFloat(HebdoMixteCPPH),
                        StringVersBool(CompetiteurActif),
                        StringVersBool(Mute),
                        StringVersBool(Unss),
                        StringVersBool(Fnsu),
                        StringVersPlume(MeilleurPlume));

                    var joueur = new Joueur(Licence, NumeroClub, champsPoona);

                    joueurs.Add(joueur);

                }

                return joueurs;
            }
        }

        private Plume StringVersPlume(string plumeAsString)
        {
            plumeAsString = plumeAsString.ToLower();
            if (plumeAsString.Contains("blanc"))
                return Plume.Blanche;
            else if (plumeAsString.Contains("jaune"))
                return Plume.Jaune;
            else if (plumeAsString.Contains("vert"))
                return Plume.Verte;
            else if (plumeAsString.Contains("bleu"))
                return Plume.Bleue;
            else if (plumeAsString.Contains("rouge"))
                return Plume.Rouge;
            else
                return Plume.Aucune;
        }

        private bool StringVersBool(string boolAsString)
        {
            boolAsString = boolAsString.ToLower();
            if (boolAsString.Contains("oui"))
                return true;
            else if (boolAsString.Contains("true"))
                return true;
            else if (boolAsString.Contains("1"))
                return true;
            else
                return false;

        }

        private Categorie StringVersCategorie(string categorieAsString)
        {
            categorieAsString = categorieAsString.ToLower().Trim();
            categorieAsString.Replace(" ", "");
            categorieAsString.Replace("é", "e");
            switch (categorieAsString)
            {
                case "poussin1":
                    return Categorie.Poussin1;
                case "poussin2":
                    return Categorie.Poussin2;
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
            }
            return Categorie.Aucune;
        }

        private float StringVersFloat(string floatAsString)
        {
            try
            {
                return float.Parse(floatAsString);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private int StringVersInt(string intAsString)
        {
            try
            {
                return int.Parse(intAsString);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
