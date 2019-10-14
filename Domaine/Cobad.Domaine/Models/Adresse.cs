using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine
{
    public class Adresse
    {
        public Adresse() { }

        public Adresse(string pays, string codePostal, string cedex, string ville, string numeroEtRue, string pointRemise, string localisation, string distribution)
        {
            Pays = pays;
            CodePostal = codePostal;
            Cedex = cedex;
            Ville = ville;
            NumeroEtRue = numeroEtRue;
            PointRemise = pointRemise;
            Localisation = localisation;
            Distribution = distribution;
        }

        public string Pays { get; set; }
        public string CodePostal { get; set; }
        public string Cedex { get; set; }
        public string Ville { get; set; }
        public string NumeroEtRue { get; set; }
        public string PointRemise { get; set; }
        public string Localisation { get; set; }
        public string Distribution { get; set; }
    }
}
