using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.Metier.Modificateurs
{
    public class ModificateurClub : IModificateurClub
    {

        private IRepertoireClubs repertoireClubs;

        private ICollection<Personnel> personnelAjoutes = new List<Personnel>();
        private ISet<string> personnelRetires = new HashSet<string>();
        private Club clubAModiifer;


        public ModificateurClub(IRepertoireClubs repertoireClubs, string numeroDuClubAModifier)
        {
            this.repertoireClubs = repertoireClubs;
            this.clubAModiifer = repertoireClubs.ObtenirClubParNumero(numeroDuClubAModifier);
        }

        public IModificateurClub AjouterPersonnel(Personnel personnel)
        {
            clubAModiifer.champsPropresACobad.Personnel.Add(personnel);
            return this;
        }

        public IModificateurClub RetirerPersonnel(string nom)
        {
            clubAModiifer.champsPropresACobad.Personnel.RemoveAll(personnel => personnel.Nom == nom);
            return this;
        }

        public Club Sauvegarder()
        {
            repertoireClubs.MettreAJour(clubAModiifer);
            return clubAModiifer;
        }
    }
}
