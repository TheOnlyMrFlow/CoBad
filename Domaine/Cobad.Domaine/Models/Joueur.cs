using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobad.Domaine
{
    public class Joueur
    {
        public class ChampsPoona
        {
            public int Licence { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public int AgeFinSaison { get; set; }
            public char Sexe { get; set; }
            public string Ville { get; set; }
            public string Tel { get; set; }
            public string Mail { get; set; }
            public string NumeroClub { get; set; }
            public string SigleClub { get; set; }
            public Categorie Categorie { get; set; }
            public string HebdoSimpleClassement { get; set; }
            public float HebdoSimpleCPPH { get; set; }
            public string HebdoDoubleClassement { get; set; }
            public float HebdoDoubleCPPH { get; set; }
            public string HebdoMixteClassement { get; set; }
            public string HebdoMixteCPPH { get; set; }
            public bool CompetiteurActif { get; set; }
            public bool Mute { get; set; }
            public bool Unss { get; set; }
            public bool Fnsu { get; set; }
            public Plume MeilleurPlume { get; set; }
        }

        public class ChampsCobad
        {
            public string Tel { get; set; }

            public string Mail { get; set; }
        }


        public ChampsPoona ChampsPropresAPoona { get; set; } = new ChampsPoona();

        public ChampsCobad ChampsPropresACobad { get; set; } = new ChampsCobad();

    }
}
