using System.Collections.Generic;

namespace Cobad.Domaine.Metier.Filtres
{
    public interface IFiltreJoueur
    {
        IFiltreJoueur FiltrerParLicense(int license);
        IFiltreJoueur FiltrerParNom(string nom);

        IFiltreJoueur FiltrerParClub(string numeroClub);

        IFiltreJoueur FiltrerparSexe(char sexe);

        IFiltreJoueur FiltrerParCategorie(Categorie categorie);
        IEnumerable<Joueur> OrdonnerParNom();

        IEnumerable<Joueur> OrdonnerParDefaut();

        string GenererMailingList(string sperateur);
    }
}