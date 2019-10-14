using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Createurs
{
    public class CreateurCollectif : ICreateurCollectif
    {
        internal CreateurCollectif() { }

        public CreateurCollectif DontLeNomEst(string nom)
        {
            throw new NotImplementedException();
        }

        public Collectif Creer()
        {
            throw new NotImplementedException();
        }
    }
}
