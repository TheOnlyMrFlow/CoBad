using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL.Adapters
{
    public class RepertoireCollectifs : IRepertoireCollectifs
    {
        public void Ajouter(Collectif collectif)
        {
            throw new NotImplementedException();
        }

        public void MettreAJour(Collectif collectif)
        {
            throw new NotImplementedException();
        }

        public void MettreAJourOuAjouterSiExistePas(Collectif collectif)
        {
            throw new NotImplementedException();
        }

        public Collectif ObtenirCollectifParNom(string nom)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collectif> ObtenirTousLesCollectifs()
        {
            throw new NotImplementedException();
        }

        public void Supprimer(string nomCollectif)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(Collectif collectif)
        {
            throw new NotImplementedException();
        }
    }
}
