using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Modificateurs
{
    public class ModificateurClub : IModificateurClub
    {

        private IRepertoireClubs repertoireClubs;

        private ICollection<Personnel> personnelAjoutes = new List<Personnel>();
        private ISet<string> personnelRetires = new HashSet<string>();

        public ModificateurClub(IRepertoireClubs repertoireClubs)
        {
            this.repertoireClubs = repertoireClubs;
        }

        public IModificateurClub AjouterPersonnel(Personnel personnel)
        {
            personnelAjoutes.Add(personnel);
            return this;
        }

        public IModificateurClub RetirerPersonnel(string nom)
        {
            personnelRetires.Add(nom);
            return this;
        }

        public Club Sauvegarder()
        {
            throw new NotImplementedException();
        }
    }
}
