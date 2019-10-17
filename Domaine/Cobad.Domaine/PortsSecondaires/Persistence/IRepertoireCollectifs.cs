using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine.PortsSecondaires.Persistence
{
    public interface IRepertoireCollectifs
    {
        bool Existe(string nomCollectif);
        Collectif ObtenirCollectifParNom(string nom);
        IEnumerable<Collectif> ObtenirTousLesCollectifs();
        void Ajouter(Collectif collectif);
        void MettreAJour(Collectif collectif);
        void Supprimer(string nomCollectif);
        void Supprimer(Collectif collectif);
        void MettreAJourOuAjouterSiExistePas(Collectif collectif);
    }
}
