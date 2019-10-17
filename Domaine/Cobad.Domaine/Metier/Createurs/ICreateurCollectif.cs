using System.Collections.Generic;

namespace Cobad.Domaine.Metier.Createurs
{
    public interface ICreateurCollectif
    {
        Collectif Creer();
        ICreateurCollectif DontLeNomEst(string nom);

        ICreateurCollectif DontLesCategoriesSont(IEnumerable<Categorie> categories);

        ICreateurCollectif DontLesMembresSont(IEnumerable<Joueur> membres);
    }
}